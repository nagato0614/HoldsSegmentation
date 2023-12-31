import tensorflow as tf
import tensorflow_datasets as tfds

# tf のバージョンを確認
print(tf.__version__)

# 現在のディレクトリ
import os

from tensorflow_examples.models.pix2pix import pix2pix

from IPython.display import clear_output
import matplotlib.pyplot as plt
import matplotlib.image as mpimg
import numpy as np


def normalize(input_image, input_mask):
    input_image = tf.cast(input_image, tf.float32) / 255.0
    input_mask -= 1
    return input_image, input_mask


def load_image(datapoint):
    input_image = tf.image.resize(datapoint['image'], (128, 128))
    input_mask = tf.image.resize(datapoint['segmentation_mask'], (128, 128))

    input_image, input_mask = normalize(input_image, input_mask)

    return input_image, input_mask


# 画像のラベル一覧
class_names = ['Holds', 'Volume', 'Background']

# 画像の色を定義
class_colors = [[255, 0, 0], [0, 255, 0], [0, 0, 255]]

os.getcwd()
input_file_path = os.getcwd() + '\images\workspace\input'
segment_file_path = os.getcwd() + '\images\workspace\segment'

# ファイル名を取得
import glob

input_file_list = glob.glob(input_file_path + '/*')
segment_file_list = glob.glob(segment_file_path + '/*')

# 画像を読み込む
import numpy as np


def load_input(file_path):
    print(file_path)
    # png を読み込む
    png_img = tf.io.read_file(file_path)
    input_image = tf.image.decode_png(png_img, channels=3)
    return input_image


def load_segment(file_path):
    print(file_path)
    # png を numpyとして読み込む
    png_img = np.array(
        tf.image.decode_png(tf.io.read_file(file_path), channels=3))

    # 新しい形状の配列を初期化
    class_indices = np.zeros((png_img.shape[0], png_img.shape[1], 1), dtype=int)

    # 各クラスカラーに対してループ
    for index, color in enumerate(class_colors):
        # クラスカラーに一致するピクセルを検索し、インデックスで置換
        class_indices[(png_img == color).all(axis=-1)] = index

    # tf に変換
    class_indices = tf.convert_to_tensor(class_indices, dtype=tf.int8)
    return class_indices


# 一度すべての画像を読み込んだあとテストとトレーニングに分ける
input_images = []
segment_images = []
for input_file, segment_file in zip(input_file_list, segment_file_list):
    input_images.append(load_input(input_file))
    segment_images.append(load_segment(segment_file))

# テストとトレーニングに分ける
train_images = input_images[:int(len(input_images) * 0.5)]
test_images = input_images[int(len(input_images) * 0.5):]

train_segments = segment_images[:int(len(segment_images) * 0.5)]
test_segments = segment_images[int(len(segment_images) * 0.5):]

# データセットに変換. 画像トラベルを一つにする
train_images = tf.data.Dataset.from_tensor_slices(
    (train_images, train_segments))
test_images = tf.data.Dataset.from_tensor_slices(
    (test_images, test_segments))

print(train_images)

