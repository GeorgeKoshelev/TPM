using System.Collections.Generic;
using TPM.TPM.Neuron;
using System.Linq;

namespace TPM.TPM.Layer
{
    public class Layer : ILayer
    {
        public Layer(List<INeuron> neurons )
        {
            Neurons = neurons;
        }

        public List<INeuron> Neurons { get; private set; }

        public INeuron this[int index]
        {
            get { return Neurons[index]; }
        }

        public void Run()
        {
            Neurons.ForEach(x=> x.Run());
        }

        public int GetOutput()
        {
            return Neurons.Sum(x => x.Output);
        }
    }
}
