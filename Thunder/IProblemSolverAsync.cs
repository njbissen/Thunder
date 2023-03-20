using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Thunder
{
	public interface IProblemSolverAsync
	{
		Task<Solution> Solve(IEnumerable<Node> nodes, Action<Solution> reportSolution, CancellationToken cancellationToken);
	}
}
