using TPM.TPM.Layer;
using System.Linq;

namespace TPM.TPM
{
    public class TPM
    {
        public ILayer InputLayer { get; private set; }
        public ILayer OutputLayer { get; private set; }


        public TPM(ILayer inputLayer , ILayer outputLayer)
        {
            InputLayer = inputLayer;
            OutputLayer = outputLayer;
        }

        public int Run(int[] input)
        {
            var i = 0;
            Refresh();
            InputLayer.Neurons.ForEach(x => x.Input = input[i++]);
            InputLayer.Run();
            return OutputLayer.Neurons.First().Output;
        }

        public void Refresh()
        {
            InputLayer.NextLayer.Neurons.ForEach(x=> x.Input = 0);
            OutputLayer.Neurons.ForEach(x=>x.Input = 1);
        }
    }
}
