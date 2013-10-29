using System;
using System.Collections.Generic;
using TPM.TPM.Neuron;

namespace TPM.TPM
{
    public class TPMFactory
    {
        public static TPM GetInstance(TPMConfiguration configuration)
        {
            var outputNeuron = new Neuron.Neuron();
            var outputLayer = new Layer.Layer(new List<INeuron>{outputNeuron});

            var hiddenNeurons = new List<INeuron>();
            for (var i = 0; i < configuration.HiddenNeuronCount; i++)
            {
                var neuron = new Neuron.Neuron();

                var synapse = new Synapse.Synapse(neuron, outputNeuron, 1);
                neuron.TargetSynapses.Add(synapse);
                outputNeuron.SourceSynapses.Add(synapse);
                hiddenNeurons.Add(neuron);
            }

            var inputNeurons = new List<INeuron>();

            var random = new Random();
            for (var i = 0; i < configuration.InputNeuronCount; i++)
            {
                var neuron = new Neuron.Neuron();
                foreach (var hiddenNeuron in hiddenNeurons)
                {
                    var weight = random.Next(configuration.WeightRange);
                    var synapse = new Synapse.Synapse(neuron , hiddenNeuron , weight);
                    neuron.TargetSynapses.Add(synapse);
                    hiddenNeuron.SourceSynapses.Add(synapse);
                }
                inputNeurons.Add(neuron);
            }

            var inputLayer = new Layer.Layer(inputNeurons);

            return new TPM(inputLayer , outputLayer);
        }
        
    }
}
