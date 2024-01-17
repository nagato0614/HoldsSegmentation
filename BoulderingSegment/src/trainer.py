import os

import matplotlib.pyplot as plt
import numpy as np
import tensorflow as tf

from BoulderingSegment.src.dataloader import BoulderingSegmentDataloader


class Trainer:
    CLASS_COLORS = [
        [255, 0, 0],  # Background
        [0, 128, 0],  # Holds
        [0, 0, 255],  # Volume
        [152, 251, 152],  # Human
        [255, 255, 0]  # Mat
    ]

    # ホールドとボリュームを同じクラスとして扱う
    CLASS_LABELS = [0, 1, 1, 2, 3]

    # 画像サイズ
    IMAGE_HEIGHT = 128
    IMAGE_WIDTH = 128

    def __init__(self):
        self.dataset_path = os.getcwd() + '/../../HoldsSegmentationDatasets'
        self.dataloader = BoulderingSegmentDataloader(file_root_path=self.dataset_path)
        self.class_colors = self.dataloader.class_colors
        self.class_names = self.dataloader.class_names

    def _create_colored_mask(self, mask):
        """
        マスクに色を適用する関数
        """
        colored_mask = np.zeros((*mask.shape, 3), dtype=np.uint8)
        for i, color in enumerate(self.class_colors):
            colored_mask[mask == i] = np.array(color)
        return colored_mask

    def _display(self, display_list):
        plt.figure(figsize=(15, 15))

        title = ['Input Image', 'True Mask', 'Predicted Mask']

        for i in range(len(display_list)):
            plt.subplot(1, len(display_list), i + 1)
            plt.title(title[i])

            # マスクの場合、色を適用
            if i > 0:  # Input Image は除外
                display_image = self._create_colored_mask(display_list[i])
                # 不要な軸が含まれている場合は削除しておく
                if len(display_image.shape) > 3:
                    display_image = np.squeeze(display_image, axis=2)
                display_image = tf.keras.utils.array_to_img(display_image)
            else:
                # 不要な軸が含まれている場合は削除しておく
                if len(display_list[i].shape) > 3:
                    display_list[i] = np.squeeze(display_list[i], axis=3)
                display_image = tf.keras.utils.array_to_img(display_list[i])

            plt.imshow(display_image)
            plt.axis('off')

        # クラス名と色の凡例を表示
        patches = [plt.plot([], [], marker="s",
                            ms=10, ls="", mec=None, color=np.array(color) / 255,
                            label="{:s}".format(self.class_names[i]))[0] for i, color in
                   enumerate(self.class_colors)]
        plt.legend(handles=patches, bbox_to_anchor=(1.05, 1), loc=2, borderaxespad=0.)

        plt.show()
