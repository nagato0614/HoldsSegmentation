import tensorflow as tf


class CustomMeanIoU(tf.keras.metrics.Metric):
    def __init__(self, num_classes,
                 name='custom_mean_iou', c_name=None,
                 dtype=None):
        super(CustomMeanIoU, self).__init__(name=name, dtype=dtype)
        self.num_classes = num_classes
        self.true_positives = [
            self.add_weight('true_positive_{}'.format(i), initializer='zeros')
            for i in range(self.num_classes)]
        self.false_positives = [
            self.add_weight('false_positive_{}'.format(i), initializer='zeros')
            for i in range(self.num_classes)]
        self.false_negatives = [
            self.add_weight('false_negative_{}'.format(i), initializer='zeros')
            for i in range(self.num_classes)]

        if c_name is not None:
            self.c_name = c_name
        else:
            self.c_name = [str(i) for i in range(self.num_classes)]

        self.iot_dict = {}
        for i in range(self.num_classes):
            self.iot_dict[self.c_name[i]] = 0

    def update_state(self, y_true, y_pred, sample_weight=None):
        """
        バッチごとにIoUを計算
        :param y_true:
        :param y_pred:
        :param sample_weight:
        :return:
        """

        # スパース形式からone-hot形式に変換
        y_true = tf.one_hot(tf.cast(y_true, tf.int32), self.num_classes)

        # 不要な行を削除
        y_true = tf.cast(tf.squeeze(y_true, axis=3), tf.int32)

        # 最大値を持つインデックスを取得
        y_pred = tf.argmax(y_pred, axis=-1)
        y_pred = tf.one_hot(tf.cast(y_pred, tf.int32), self.num_classes)

        # 各クラスごとにTrue Positive, False Positive, False Negativeを計算
        for i in range(self.num_classes):
            y_true_i = tf.cast(tf.equal(y_true, i), tf.int32)
            y_pred_i = tf.cast(tf.equal(y_pred, i), tf.int32)

            # int32型のテンソルをfloat32型にキャスト
            true_positives_update = tf.cast(tf.reduce_sum(y_true_i * y_pred_i),
                                            tf.float32)
            false_positives_update = tf.cast(
                tf.reduce_sum((1 - y_true_i) * y_pred_i), tf.float32)
            false_negatives_update = tf.cast(
                tf.reduce_sum(y_true_i * (1 - y_pred_i)), tf.float32)

            self.true_positives[i].assign_add(true_positives_update)
            self.false_positives[i].assign_add(false_positives_update)
            self.false_negatives[i].assign_add(false_negatives_update)

    def result(self):
        """
        各クラスごとにIoUを計算
        :return:
        """
        # 各クラスごとにIoUを計算
        for i in range(self.num_classes):
            iou = self.true_positives[i] / (
                    self.true_positives[i] + self.false_positives[i] +
                    self.false_negatives[i] + tf.keras.backend.epsilon())
            self.iot_dict[self.c_name[i]] = iou
        return self.iot_dict

    def reset_state(self):
        """
        エポック終わりにすべての結果をリセットする
        :return:
        """
        for i in range(self.num_classes):
            self.true_positives[i].assign(0)
            self.false_positives[i].assign(0)
            self.false_negatives[i].assign(0)

        # iot_dict を初期化
        for i in range(self.num_classes):
            self.iot_dict[self.c_name[i]] = 0

    def get_config(self):
        config = super(CustomMeanIoU, self).get_config()
        config.update({
            'num_classes': self.num_classes,
            'c_name': self.c_name
        })
        return config

    @classmethod
    def from_config(cls, config):
        return cls(**config)
