using System;
using System.Collections.Generic;
using TPM.TPM;

namespace TPM
{
    public class Tutor
    {
        private readonly TPMConfiguration configuration;

        public Tutor(TPMConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SyncTPM(TPM.TPM m1 , TPM.TPM m2)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                var weightsOld1 = m1.InputLayer.GetTargetWeights();
                var weightsold2 = m2.InputLayer.GetTargetWeights();

                var rand = new Random(DateTime.Now.Millisecond);
                var input = new List<int>();
                for (int j = 0; j < m1.InputLayer.Neurons.Count; j++)
                {
                    var r = rand.Next(-1, 2);
                    while (r == 0)
                    {
                        r = rand.Next(-1, 2);
                    }
                    input.Add(r);
                }
                m1.Run(input.ToArray());
                m2.Run(input.ToArray());
                if (m1.OutputLayer.GetOutput() == m2.OutputLayer.GetOutput()){
                    UpdateWeights(m1);
                    UpdateWeights(m2);
                }

                var weights1 = m1.InputLayer.GetTargetWeights();
                var weights2 = m2.InputLayer.GetTargetWeights();

                var success = true;
                for (var k = 0; k < weights1.Count; k++)
                {
                    if (weights1[k] != weights2[k])
                    {
                        success = false;
                        break;
                    }
                }
                if (success)
                {
                    throw new Exception();
                }
            }

        }
        
        private void UpdateWeights(TPM.TPM tpm)
        {
            var output = tpm.OutputLayer.GetOutput();
            foreach (var neuron in tpm.InputLayer.Neurons)
            {
                foreach (var synapse in neuron.TargetSynapses)
                {
                    if (output != synapse.TargetNeuron.Output) //may be problem
                        continue;
                    var newWeight = synapse.Weight;
                    newWeight += neuron.Input * output;
                    if (newWeight > configuration.WeightRange)
                        newWeight = configuration.WeightRange;
                    if (newWeight < configuration.WeightRange * -1)
                        newWeight = configuration.WeightRange * -1;
                    synapse.Weight = newWeight;   
                }
            }
        }

    }
}
