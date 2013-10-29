using TPM.TPM.Neuron;

namespace TPM.TPM.Synapse
{
    public class SummarizeSynapse : Synapse
    {
        public SummarizeSynapse(INeuron sourceNeuron, INeuron targetNeuron, int weight = int.MinValue)
            : base(sourceNeuron, targetNeuron, weight){}

        public override void Propagate()
        {
            TargetNeuron.Input = Weight*SourceNeuron.Output;
        }
    }
}
