using TPM.TPM.Neuron;

namespace TPM.TPM.Synapse
{
    public interface ISynapse
    {
        int Weight { get; set; }

        INeuron SourceNeuron { get; }
        INeuron TargetNeuron { get; }

        void Propagate();
        void UpdateWeight(int newWeight);
    }
}