using System;
using TPM.TPM.Neuron;

namespace TPM.TPM.Synapse
{
    public class MultiplyerSynapse : Synapse
    {
        public MultiplyerSynapse(INeuron sourceNeuron, INeuron targetNeuron, int weight = Int32.MinValue) : base(sourceNeuron, targetNeuron, weight)
        {
        }

        public override void Propagate()
        {
            TargetNeuron.Input *= SourceNeuron.Output;
        }
    }
}
