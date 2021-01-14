using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.PythonClasses
{
    public class GenreClassifier
    {
        private double _learningRate;
        public double SpikingThreshold { get; set; }
        public double InputLayerSize { get; set; }
        public double TimeThreshold { get; set; }
        public int Classifications { get; set; }
        public int HiddenLayerNum { get; set; }
        public List<double> TrainDataList { get; set; }
        public List<Neuron> InputLayer { get; set; }
        public List<Neuron> MiddleLayer { get; set; }
        public List<Neuron> OutputLayer { get; set; }

        public void Train()
        {
        }

        public void SaveWeights()
        {
        }

        public void GetWeights()
        {
        }

        public void TrainExcitatoryNeurons(List<double> input)
        {
        }

        public void TrainInhibitoryNeurons(List<double> input)
        {
        }

        public List<string> Classify(List<double> input)
        {
            return Enumerable.Empty<string>().ToList();
        }

        public List<double> GetFilesData(List<string> fileNames)
        {
            return Enumerable.Empty<double>().ToList();
        }

        public List<double> GetTrainFilesData(List<string> fileNames)
        {
            return Enumerable.Empty<double>().ToList();
        }
    }
}
