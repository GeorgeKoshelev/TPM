using System.Collections.Generic;
using TPM.TPM.Synapse;

namespace TPM.TPM.Neuron
{
    public interface INeuron
    {
        int Input { get; set; }
        int Output { get; set; }

        List<ISynapse> SourceSynapses { get; }
        List<ISynapse> TargetSynapses { get; }

        void Run();
    }
}
