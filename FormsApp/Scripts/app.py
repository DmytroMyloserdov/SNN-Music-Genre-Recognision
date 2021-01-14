import argparse
from snn import SNN

parser = argparse.ArgumentParser(description='SNN music genre recognision')
parser.add_argument('--recognise', dest='recognizionPath', type=str, help='System path to file for genre recognision')
parser.add_argument('--train', dest='trainFolderPath', type=str, help='System path to folder with train data')

args = parser.parse_args()

nn = SNN()

if args.recognizionPath:
    print('recog')
    #print(snn.recognise(args.recognisionPath))

if args.trainFolderPath:
    print('train')
    #snn.train(args.trainFolderPath)


