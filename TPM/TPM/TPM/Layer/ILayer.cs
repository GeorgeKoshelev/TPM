using System.Collections.Generic;
using TPM.TPM.Neuron;

namespace TPM.TPM.Layer
{
    public interface ILayer
    {
        List<INeuron> Neurons { get; }
        ILayer NextLayer { get; }

        INeuron this[int index] { get; }

        void Run();
        int GetOutput();
        List<int> GetTargetWeights();
    }
}
