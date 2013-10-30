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
            var outputLayer = new Layer.Layer(new List<INeuron> { outputNeuron }, null);

            var hiddenNeurons = new List<INeuron>();
            for (var i = 0; i < configuration.HiddenNeuronCount; i++)
            {
                var neuron = new Neuron.Neuron();

                var synapse = new Synapse.MultiplyerSynapse(neuron, outputNeuron);
                neuron.TargetSynapses.Add(synapse);
                outputNeuron.SourceSynapses.Add(synapse);
                hiddenNeurons.Add(neuron);
            }
            var hiddenLayer = new Layer.Layer(hiddenNeurons, outputLayer);


            var inputNeurons = new List<INeuron>();
            var random = new Random(DateTime.Now.Millisecond);

            foreach (var hiddenNeuron in hiddenNeurons)
            {
                for (int i = 0; i < configuration.InputNeuronCount; i++)
                {
                    var neuron = new Neuron.Neuron();
                    var weight = random.Next(configuration.WeightRange * -1, configuration.WeightRange + 1);
                    var synapse = new Synapse.SummarizeSynapse(neuron, hiddenNeuron, weight);
                    neuron.TargetSynapses.Add(synapse);
                    hiddenNeuron.SourceSynapses.Add(synapse);
                    inputNeurons.Add(neuron);
                }
            }
            var inputLayer = new Layer.Layer(inputNeurons, hiddenLayer);
            return new TPM(inputLayer, outputLayer);
        }
    }
}
