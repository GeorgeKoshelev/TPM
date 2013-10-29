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
            this.nextLayer = nextLayer;
        }

        public List<INeuron> Neurons { get; private set; }
        private ILayer nextLayer { get; set; }

        public INeuron this[int index]
        {
            get { return Neurons[index]; }
        }

        public void Run()
        {
            Neurons.ForEach(x=> x.Run());
            if (nextLayer != null)
                nextLayer.Run();
        }

        public int GetOutput()
        {
            return Neurons.Sum(x => x.Output);
        }
    }
}
