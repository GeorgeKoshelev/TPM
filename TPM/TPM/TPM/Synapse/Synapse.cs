using TPM.TPM.Neuron;

namespace TPM.TPM.Synapse
{
    public abstract class Synapse: ISynapse
    {
        protected Synapse(INeuron sourceNeuron, INeuron targetNeuron, int weight = int.MinValue)
        {
            SourceNeuron = sourceNeuron;
            TargetNeuron = targetNeuron;
            Weight = weight;
        }

        public int Weight { get; set; }

        public INeuron SourceNeuron { get; private set; }
        
        public INeuron TargetNeuron { get; private set; }

        public abstract void Propagate();
        
        public void UpdateWeight(int newWeight)
        {
            Weight = newWeight;
        }
    }
}
