using TPM.TPM.Neuron;

namespace TPM.TPM.Synapse
{
    public class Synapse: ISynapse
    {
        public Synapse(INeuron sourceNeuron, INeuron targetNeuron, int weight)
        {
            SourceNeuron = sourceNeuron;
            TargetNeuron = targetNeuron;
            Weight = weight;
        }

        public int Weight { get; set; }

        public INeuron SourceNeuron { get; private set; }
        
        public INeuron TargetNeuron { get; private set; }
        
        public void Propagate()
        {
            TargetNeuron.Input = Weight*SourceNeuron.Output;
        }
    }
}
