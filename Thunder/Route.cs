using System;
using System.Collections.Generic;

namespace Thunder
{
	public class Route
	{
		public Route()
		{
		}

		public IEnumerable<Node> Generate(int count)
		{
			return Generate(count, (i) => i * i);
		}

		public IEnumerable<Node> Generate(int count, int maxBoundary)
		{
			var clouds = Generate(count, (i) => Random.Shared.Next(maxBoundary));
			Distance = double.MinValue;
			return clouds;
		}

		public double Distance { get; private set; }

		private void CalculateDistance(IEnumerable<Node> nodes)
		{
			var previous = default(Node);
			foreach (var node in nodes)
			{
				if (previous != null)
				{
					Distance += node.GetDistance(previous);
				}
				previous = node;
			}
		}

		private IEnumerable<Node> Generate(int count, Func<int, int> getCoordinate)
		{
			var nodes = new List<Node>();
			for (var i = 0; i < count; i++)
			{
				var node = new Node()
				{
					Id = i,
					X = getCoordinate(i),
					Y = getCoordinate(i)
				};
				nodes.Add(node);
			}

			CalculateDistance(nodes);
			return nodes;
		}
	}
}
