using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CreditApproval.Services
{
    public class ApprovalStatus
    {
        [JsonProperty("IsApproved")]
        public bool IsApproved { get; set; }

        [JsonProperty("Scored Probabilities")]
        public float Probability { get; set; }
    }

    public class Results
    {
        [JsonProperty("ApprovalStatus")]
        public IList<ApprovalStatus> ApprovalStatus { get; set; }
    }

    public class CreditServiceResponse
    {
        [JsonProperty("Results")]
        public Results Results { get; set; }

        public ApprovalStatus GetStatus() => Results.ApprovalStatus.First();
    }
}
