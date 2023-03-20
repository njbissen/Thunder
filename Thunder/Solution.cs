using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thunder
{
	public class Solution
	{
		public string Id { get; set; }
		public decimal Distance { get; set; }
		public IEnumerable<Node> Nodes { get; set; }
		public int TotalSolutions { get; set; }
		public decimal ExecutionTime { get; set; }
		public string ProblemId { get; set; }
		public string Source { get; set; }

	}
}
