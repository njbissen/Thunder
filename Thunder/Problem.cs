using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thunder
{
	public class Problem
	{
		public string Id { get; set; }
		public IEnumerable<Node> Nodes { get; set; }
		public int TimeToLive { get; set; }
		public double? Distance { get; set; }
	}
}
