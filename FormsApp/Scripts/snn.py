import librosa
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import os
import pathlib
import csv

from sklearn.model_selection import train_test_split
from sklearn.preprocessing import LabelEncoder, StandardScaler

import keras
from keras import layers
from keras import layers
import keras
from keras.models import Sequential

import warnings
warnings.filterwarnings('ignore')

class SNN:
    def __init__(self):
        self.model = any
        self.loader = DataLoader()

    def recognize(self, songPath: str):
        self.loadModelAndWeights()
        self.loader.loadBaseData()
        self.loader.loadSongData(songPath)
        x,y = self.createRecognizionData()

        prediction = self.model.predict(x)
        max_index_col = np.argmax(prediction, axis=1)

        map = {
            0: "blues",
            1: "classical",
            2: "country",
            3: "disco",
            4: "hiphop",
            5: "jazz",
            6: "metal",
            7: "pop",
            8: "reggae",
            9: "rock"
        }

        self.deleteTempData()
        return map[max_index_col[max_index_col.size - 1]]

    def train(self, trainFolder: str):
        self.loader.loadTraingData(trainFolder)
        x_train, y_train = self.createTraingData()
        self.createModel(x_train)
        self.model.fit(x_train,y_train,epochs=100,batch_size=128)
        self.saveModelAndWeights()
        self.deleteTempData()

    def createModel(self, Xtrain):
        self.model = Sequential()
        self.model.add(layers.Dense(256, activation='relu', input_shape=(Xtrain.shape[1],)))
        self.model.add(layers.Dense(128, activation='relu'))
        self.model.add(layers.Dense(64, activation='relu'))
        self.model.add(layers.Dense(10, activation='softmax'))

        self.model.compile(optimizer='adam',
              loss='sparse_categorical_crossentropy',
              metrics=['accuracy'])

    def createTraingData(self):
        X, y = self.parseCsvData()
        X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.001)
        return X_train, y_train

    def createRecognizionData(self):
        return self.parseCsvData()

    def parseCsvData(self):
        data = pd.read_csv('dataset.csv')
        data.head()

        data = data.drop(['filename'],axis=1)

        genre_list = data.iloc[:, -1]
        encoder = LabelEncoder()
        y = encoder.fit_transform(genre_list)

        scaler = StandardScaler()
        X = scaler.fit_transform(np.array(data.iloc[:, :-1], dtype = float))
        return X, y

    def deleteTempData(self):
        os.remove('dataset.csv')

    def saveModelAndWeights(self):
        self.model.save('model')
        self.model.save_weights("weights.h5")

    def loadModelAndWeights(self):
        self.model = keras.models.load_model('model')
        self.model.load_weights("weights.h5")


class DataLoader:

    def createDataSetFile(self):
        header = 'filename chroma_stft rmse spectral_centroid spectral_bandwidth rolloff zero_crossing_rate'
        for i in range(1, 21):
            header += f' mfcc{i}'
        header += ' label'
        header = header.split()

        file = open('dataset.csv', 'w', newline='')
        with file:
            writer = csv.writer(file)
            writer.writerow(header)

    def loadBaseData(self):
        self.createDataSetFile()
        for fileName in os.listdir('./base_data'):
            self.loadSongData(f'./{fileName}')

    def loadTraingData(self, trainFolder: str):
        self.createDataSetFile()
        genres = 'blues classical country disco hiphop jazz metal pop reggae rock'.split()
        for g in genres:
            for fileName in os.listdir(f'{trainFolder}/{g}'):
                self.loadSongData(f'{trainFolder}/{g}/{fileName}')

    def loadSongData(self, songPath: str):
        y, sr = librosa.load(songPath, mono=True, duration=30)
        rmse = librosa.feature.rmse(y=y)
        chroma_stft = librosa.feature.chroma_stft(y=y, sr=sr)
        spec_cent = librosa.feature.spectral_centroid(y=y, sr=sr)
        spec_bw = librosa.feature.spectral_bandwidth(y=y, sr=sr)
        rolloff = librosa.feature.spectral_rolloff(y=y, sr=sr)
        zcr = librosa.feature.zero_crossing_rate(y)
        mfcc = librosa.feature.mfcc(y=y, sr=sr)
        to_append = f'{songPath} {np.mean(chroma_stft)} {np.mean(rmse)} {np.mean(spec_cent)} {np.mean(spec_bw)} {np.mean(rolloff)} {np.mean(zcr)}'    
        for e in mfcc:
            to_append += f' {np.mean(e)}'
        file = open('dataset.csv', 'a', newline='')
        with file:
            writer = csv.writer(file)
            writer.writerow(to_append.split())


nn = SNN()
#nn.recognize('./drive/MyDrive/GTZAN/blues/blues.00000.wav')
nn.train('./drive/MyDrive/GTZAN')