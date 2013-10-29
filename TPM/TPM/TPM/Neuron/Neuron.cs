using System.Collections.Generic;
using TPM.TPM.Synapse;

namespace TPM.TPM.Neuron
{
    public class Neuron : INeuron
    {
        public Neuron()
        {
            SourceSynapses = new List<ISynapse>();
            TargetSynapses = new List<ISynapse>();
        }

        public int Input { get; set; }

        public int Output
        {
            get { return Input <= 0 ? -1 : 1; }
            set {  }
        }

        public List<ISynapse> SourceSynapses { get; private set; }
        public List<ISynapse> TargetSynapses { get; private set; }

        public void Run()
        {
            foreach (var targetSynapse in TargetSynapses)
            {
                targetSynapse.Propagate();
            }
        }
    }
}
