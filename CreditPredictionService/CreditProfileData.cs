using System.Collections.Generic;

namespace CreditApproval.Services
{
    public class Inputs
    {
        public IList<CreditProfile> CreditProfile { get; }

        public Inputs(CreditProfile creditProfile)
        {
            CreditProfile = new List<CreditProfile>() { creditProfile };
        }
    }

    public class CreditProfileData
    {
        public CreditProfileData(CreditProfile creditProfile)
        {
            Inputs = new Inputs(creditProfile);
        }

        public Inputs Inputs { get; }

        public Dictionary<string, string> GlobalParameters => new Dictionary<string, string>() { };
    }
}
