using System.Collections.Generic;
using TPM.TPM;

namespace TPM
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new TPMConfiguration(12, 8, 4);
            var tpm1 = TPMFactory.GetInstance(configuration);
            var tpm2 = TPMFactory.GetInstance(configuration);

            var tutor = new Tutor(configuration);
            tutor.SyncTPM(tpm1 , tpm2);

        }
    }
}
