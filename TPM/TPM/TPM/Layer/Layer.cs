using System.Collections.Generic;
using TPM.TPM.Neuron;
using System.Linq;

namespace TPM.TPM.Layer
{
    public class Layer : ILayer
    {
        public Layer(List<INeuron> neurons , ILayer nextLayer)
        {
            Neurons = neurons;
            NextLayer = nextLayer;
        }

        public List<INeuron> Neurons { get; private set; }
        public ILayer NextLayer { get; private set; }

        public INeuron this[int index]
        {
            get { return Neurons[index]; }
        }

        public void Run()
        {
            Neurons.ForEach(x=> x.Run());
            if (NextLayer != null)
                NextLayer.Run();
        }

        public int GetOutput()
        {
            return Neurons.Sum(x => x.Output);
        }

        public List<int> GetTargetWeights()
        {
            return (from neuron in Neurons from synapse in neuron.TargetSynapses select synapse.Weight).ToList();
        }
    }
}
