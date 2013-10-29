using System;

namespace TPM.TPM
{
    public class TPMConfiguration
    {
        public TPMConfiguration(int inputNeuronCount, int hiddenNeuronCount, int weightRange)
        {
            InputNeuronCount = inputNeuronCount;
            HiddenNeuronCount = hiddenNeuronCount;
            WeightRange = weightRange;
        }

        public int InputNeuronCount { get; private set; }
        public int HiddenNeuronCount { get; private set; }
        public int WeightRange { get; private set; }

        public override string ToString()
        {
            return String.Format("InputNeuronCount:{0},HiddenNeuronCount:{1},WeightRange:{2}", InputNeuronCount,
                                 HiddenNeuronCount, WeightRange);
        }
    }
}