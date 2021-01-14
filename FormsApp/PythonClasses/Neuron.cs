using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.PythonClasses
{
    public class Neuron
    {
        private double _deltaTime;
        public long DurationForSimulation { get; set; }
        public List<double> VArray { get; set; }
        public double Threshold { get; set; }
        public double ResetPotential { get; set; }
        public double InitialMembranePotential { get; set; }
        public double MembraneResistance { get; set; }
        public double Capacitance { get; set; }
        public double MembraneTimeConstant { get; set; }
        public int FiringRate { get; set; }
        public int NumberOfFired { get; set; }
        public int NumberOfNotFired { get; set; }
        public List<double> SpikeRateForData { get; set; }
        public double TotalSpikeRate { get; set; }
        public double ClassificationRate { get; set; }
        public double ClassificationActivity { get; set; }
        public List<double> Weights { get; set; }

        public double RunNeuron(double input)
        {
            return 0.0;
        } 
    }
}
