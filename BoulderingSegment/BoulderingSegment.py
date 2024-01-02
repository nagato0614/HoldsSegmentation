from tensorflow_examples.models.pix2pix import pix2pix
import tensorflow as tf
import tensorflow_datasets as tfds
from IPython.display import clear_output
import matplotlib.pyplot as plt
import os
import numpy as np
import glob

# 画像のラベル一覧
class_names = ['Background',
               'Holds',
               'Volume',
               'Mat',
               'Human',
               ]

# 画像の色を定義
class_colors = [
    [255, 0, 0],
    [0, 128, 0],
    [0, 0, 255],
    [152, 251, 152],
    [255, 255, 0]
]

clas_labels = [0, 1, 1, 2, 3]

# Volume も Holds も同じ色にする
OUTPUT_CLASSES = 4

os.getcwd()
input_file_path = os.getcwd() + '\images\workspace\input'
segment_file_path = os.getcwd() + '\images\workspace\segment'

input_file_list = glob.glob(input_file_path + '/*')
segment_file_list = glob.glob(segment_file_path + '/*')

IMAGE_WIDTH = 128
IMAGE_HEIGHT = 128

def load_input(file_path):
    # png を読み込む
    png_img = tf.io.read_file(file_path)
    input_image = tf.image.decode_png(png_img, channels=3)

    # 画像をリサイズ
    input_image = tf.image.resize(input_image, (IMAGE_WIDTH, IMAGE_HEIGHT))

    # 画像を正規化
    input_image = tf.cast(input_image, tf.float32) / 255.0

    return input_image

def load_segment(file_path):
    # png を numpyとして読み込む
    png_img = np.array(
        tf.image.decode_png(tf.io.read_file(file_path), channels=3))

    # 新しい形状の配列を初期化
    class_indices = np.zeros((png_img.shape[0], png_img.shape[1], 1), dtype=int)

    # 各クラスカラーに対してループ
    for index, color in enumerate(class_colors):
        # クラスカラーに一致するピクセルを検索し、インデックスで置換
        class_indices[(png_img == color).all(axis=-1)] = clas_labels[index]

    # tf に変換
    class_indices = tf.convert_to_tensor(class_indices, dtype=tf.int8)

    # 画像をリサイズ
    class_indices = tf.image.resize(class_indices, (IMAGE_WIDTH, IMAGE_HEIGHT))

    # 画像を正規化
    class_indices = tf.cast(class_indices, tf.float32) / 255.0

    return class_indices
def load_segment(file_path):
    # png を numpyとして読み込む
    png_img = np.array(
        tf.image.decode_png(tf.io.read_file(file_path), channels=3))

    # 新しい形状の配列を初期化
    class_indices = np.zeros((png_img.shape[0], png_img.shape[1], 1), dtype=int)

    # 各クラスカラーに対してループ
    for index, color in enumerate(class_colors):
        # クラスカラーに一致するピクセルを検索し、インデックスで置換
        class_indices[(png_img == color).all(axis=-1)] = clas_labels[index]

    # tf に変換
    class_indices = tf.convert_to_tensor(class_indices, dtype=tf.int8)

    # 画像をリサイズ
    class_indices = tf.image.resize(class_indices, (IMAGE_WIDTH, IMAGE_HEIGHT))

    # 画像を正規化
    class_indices = tf.cast(class_indices, tf.float32) / 255.0

    return class_indices

# 一度すべての画像を読み込んだあとテストとトレーニングに分ける
input_images = []
segment_images = []
for input_file, segment_file in zip(input_file_list, segment_file_list):
    input_images.append(load_input(input_file))
    segment_images.append(load_segment(segment_file))

# ランダムに画像を並び替える
image_set = []
for input, segment in zip(input_images, segment_images):
    image_set.append((input, segment))

np.random.shuffle(image_set)

input_images = []
segment_images = []
for input, segment in image_set:
    input_images.append(input)
    segment_images.append(segment)

print(f"input_images: {len(input_images)}"
      f"\nsegment_images: {len(segment_images)}")

train_image_size = int(len(input_images) * 0.9)
test_image_size = int(len(input_images) * 0.1)

# テストとトレーニングに分ける
train_images = np.array(input_images[:train_image_size])
test_images = np.array(input_images[train_image_size:])
print(f"train_images: ", train_images.shape)
print(f"test_images: ", test_images.shape)

train_segments = np.array(segment_images[:train_image_size])
test_segments = np.array(segment_images[train_image_size:])

# データセットに変換. 画像トラベルを一つにする
train_images = tf.data.Dataset.from_tensor_slices(
    (train_images, train_segments))
test_images = tf.data.Dataset.from_tensor_slices(
    (test_images, test_segments))

TRAIN_LENGTH = len(train_images)
BATCH_SIZE = 10
BUFFER_SIZE = 100
STEPS_PER_EPOCH = TRAIN_LENGTH // BATCH_SIZE

print(f"TRAIN_LENGTH: {TRAIN_LENGTH}"
      f"\nBATCH_SIZE: {BATCH_SIZE}"
      f"\nBUFFER_SIZE: {BUFFER_SIZE}"
      f"\nSTEPS_PER_EPOCH: {STEPS_PER_EPOCH}")
print(f"\ntrain_images: {len(train_images)}"
      f"\ntest_images: {len(test_images)}")