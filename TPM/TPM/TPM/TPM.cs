﻿using TPM.TPM.Layer;

namespace TPM.TPM
{
    public class TPM
    {
        public ILayer InputLayer { get; private set; }
        public ILayer OutputLayer { get; private set; }


        public TPM(ILayer inputLayer , ILayer outputLayer)
        {
            InputLayer = inputLayer;
            OutputLayer = outputLayer;
        }

    }
}
