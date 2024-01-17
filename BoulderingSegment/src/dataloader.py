import glob

import numpy as np
import tensorflow as tf


class BoulderingSegmentDataloader:

    def __init__(self,
                 file_root_path,
                 class_colors,
                 class_labels,
                 image_height,
                 image_width,
                 batch_size=5, ):
        self.file_root_path = file_root_path
        self.batch_size = batch_size
        self.class_colors = class_colors
        self.class_labels = class_labels
        self.image_height = image_height
        self.image_width = image_width
        self.OUTPUT_CLASSES = np.unique(self.class_labels).shape[0]

    def _load_image_file_list(self, filepath):
        """
        ファイルパスから画像ファイルのリストを取得する
        :param filepath:
        :return:
        """
        input_file_path = filepath + '/input'
        segment_file_path = filepath + '/segment'

        # ファイルリストを取得
        input_file_list = glob.glob(input_file_path + '/*')
        segment_file_list = glob.glob(segment_file_path + '/*')

        # ファイル名でソート
        input_file_list.sort()
        segment_file_list.sort()

        return input_file_list, segment_file_list

    def _load_input(self, file_path):
        # png を読み込む
        png_img = tf.io.read_file(file_path)
        input_image = tf.image.decode_png(png_img, channels=3)

        # 画像をリサイズ
        input_image = tf.image.resize(input_image, (self.image_height, self.image_width))

        # 画像を正規化
        input_image = tf.cast(input_image, tf.float32) / 255.0

        return input_image

    def _load_segment(self, file_path):
        # png を numpyとして読み込む
        png_img = np.array(
            tf.image.decode_png(tf.io.read_file(file_path), channels=3))

        # 新しい形状の配列を初期化
        class_indices = np.zeros((png_img.shape[0], png_img.shape[1], 1), dtype=int)

        # 各クラスカラーに対してループ
        for index, color in enumerate(self.class_colors):
            # クラスカラーに一致するピクセルを検索し、インデックスで置換
            class_indices[(png_img == color).all(axis=-1)] = self.class_labels[index]

        # tf に変換
        class_indices = tf.convert_to_tensor(class_indices, dtype=tf.int64)

        # 画像をリサイズ, リサイズするとき補間を行わないように設定
        class_indices = tf.image.resize(class_indices, (self.image_width, self.image_height),
                                        method=tf.image.ResizeMethod.NEAREST_NEIGHBOR)

        return class_indices

    def _load_images(self, input_file_list, segment_file_list):
        """
        画像を読み込む
        :param input_file_list:
        :param segment_file_list:
        :return:
        """
        input_image_list = []
        segment_image_list = []

        for input_file, segment_file in zip(input_file_list, segment_file_list):
            input_image_list.append(self._load_input(input_file))
            segment_image_list.append(self._load_segment(segment_file))

        return input_image_list, segment_image_list

    def _augment(self, in_image: list, in_labels: list):

        """
        入力画像をもとにデータをかさ増しする.
        :param in_labels:
        :param in_image:
        :return:
        """
        output_image = []
        output_labels = []
        count = 0
        for image, label in zip(in_image, in_labels):
            count += 1
            # print("augment: ", count)

            # 通常の画像
            output_image.append(image)
            output_labels.append(label)

            # 左右反転
            output_image.append(tf.image.flip_left_right(image))
            output_labels.append(tf.image.flip_left_right(label))

            # 上下反転
            output_image.append(tf.image.flip_up_down(image))
            output_labels.append(tf.image.flip_up_down(label))

            # 90度回転
            output_image.append(tf.image.rot90(image))
            output_labels.append(tf.image.rot90(label))

            # 180度回転
            output_image.append(tf.image.rot90(image, k=2))
            output_labels.append(tf.image.rot90(label, k=2))

            # 270度回転
            output_image.append(tf.image.rot90(image, k=3))
            output_labels.append(tf.image.rot90(label, k=3))

            # 輝度を変更 (0.1)
            output_image.append(tf.image.adjust_brightness(image, 0.1))
            output_labels.append(label)

            # 輝度を0.
            # 輝度を変更 (0.2)
            output_image.append(tf.image.adjust_brightness(image, 0.2))
            output_labels.append(label)

            # 彩度を変更 (0.1)
            output_image.append(tf.image.adjust_saturation(image, 0.1))
            output_labels.append(label)

            # 彩度を変更 (0.2)
            output_image.append(tf.image.adjust_saturation(image, 0.2))
            output_labels.append(label)

            # コントラストを変更 (0.1)
            output_image.append(tf.image.adjust_contrast(image, 0.1))
            output_labels.append(label)

            # 画像反転
            output_image.append(tf.image.flip_left_right(image))
            output_labels.append(tf.image.flip_left_right(label))

            # ランダムなノイズの追加
            noise = tf.random.normal(shape=tf.shape(image), mean=0.0, stddev=0.1)
            output_image.append(tf.clip_by_value(image + noise, 0.0, 1.0))
            output_labels.append(label)

            crop_size_list = [0.5, 0.75, 0.9]
            for crop_size in crop_size_list:
                # トリミング
                crop_img = tf.image.central_crop(image, crop_size)
                crop_label = tf.image.central_crop(label, crop_size)

                # 画像のサイズを元に戻す
                # 補間はかけない
                crop_img = tf.image.resize(crop_img, (self.image_width, self.image_height),
                                           method=tf.image.ResizeMethod.NEAREST_NEIGHBOR)
                crop_label = tf.image.resize(crop_label,
                                             (self.image_width, self.image_height),
                                             method=tf.image.ResizeMethod.NEAREST_NEIGHBOR)

                output_image.append(crop_img)
                output_labels.append(crop_label)

        return output_image, output_labels

    def load(self, is_augment=False):
        # ファイルリストを取得
        train_input_file_list, train_segment_file_list = self._load_image_file_list(
            self.file_root_path + '/train')
        val_input_file_list, val_segment_file_list = self._load_image_file_list(
            self.file_root_path + '/val')
        test_input_file_list, test_segment_file_list = self._load_image_file_list(
            self.file_root_path + '/test')

        # データを読み込み
        train_image_list, train_segment_list = self._load_images(train_input_file_list,
                                                                 train_segment_file_list)
        val_image_list, val_segment_list = self._load_images(val_input_file_list,
                                                             val_segment_file_list)
        test_image_list, test_segment_list = self._load_images(test_input_file_list,
                                                               test_segment_file_list)

        # データオーギュメント
        if is_augment:
            train_image_list, train_segment_list = self._augment(train_image_list,
                                                                 train_segment_list)

        # データセットを作成
        self.train_dataset = tf.data.Dataset.from_tensor_slices(
            (train_image_list, train_segment_list))

        self.val_dataset = tf.data.Dataset.from_tensor_slices(
            (val_image_list, val_segment_list))

        self.test_dataset = tf.data.Dataset.from_tensor_slices(
            (test_image_list, test_segment_list))

        # バッチサイズを設定
        self.train_dataset = (
            self.train_dataset
            .cache()
            .batch(self.batch_size)
            .repeat()
            .prefetch(buffer_size=tf.data.AUTOTUNE))

        self.val_dataset = self.val_dataset.batch(min(len(self.val_dataset), self.batch_size))
        self.test_dataset = self.test_dataset.batch(min(len(self.test_dataset), self.batch_size))

    def get_train_dataset(self):
        return self.train_dataset

    def get_val_dataset(self):
        return self.val_dataset

    def get_test_dataset(self):
        return self.test_dataset
