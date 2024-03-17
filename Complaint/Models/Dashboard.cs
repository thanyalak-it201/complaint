using Complain.Models;

namespace Complaint.Models
{
    public class Dashboard
    {
        public List<CostomerResponse> ListCostomer { get; set; }
        public List<ProblemResponse> ListProblem { get; set; }
    }

    public class CostomerResponse
    {
        public int CountCostomer { get; set; }
        public string NameCostomer { get; set; }
    }

    public class ProblemResponse
    {
        public int CountProblem { get; set; }
        public string NameProblem { get; set; }
    }
}
