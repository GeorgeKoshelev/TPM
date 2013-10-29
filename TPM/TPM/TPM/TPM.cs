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
            OutputLayer[0].Input = 1;
            InputLayer.Neurons.ForEach(x => x.Input = input[i++]);
            InputLayer.Run();
            return OutputLayer.Neurons.First().Output;
        }
    }
}
