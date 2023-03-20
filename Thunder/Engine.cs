using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Thunder
{
	public class Engine
	{
		private readonly CancellationTokenSource cancellationTokenSource;

		public Engine()
		{
			cancellationTokenSource = new CancellationTokenSource();
		}
	
		public async Task<Solution> ExecuteAsync(IEnumerable<Node> clouds, TimeSpan ttl, IProblemSolverAsync solveAsync)
		{
			cancellationTokenSource.CancelAfter(ttl);
			var cancellationToken = cancellationTokenSource.Token;
			var solution = default(Solution);

			try
			{
				var solver = solveAsync.Solve(clouds, (reportedSolution) => solution = reportedSolution, cancellationToken); 
				var monitor = Monitor(cancellationToken, solver);
				await Task.WhenAll(solver, monitor);
				solution = solver.Result;
			}
			catch (Exception ex)
			{

			}
			finally
			{
			}
			return solution;
		}

		private async Task Monitor(CancellationToken cancellationToken, Task solver)
		{
			while (!cancellationToken.IsCancellationRequested && !solver.IsCompleted)
			{
				await Task.Delay(1000, cancellationToken);
			}
			cancellationToken.ThrowIfCancellationRequested();
		}
	}
}
