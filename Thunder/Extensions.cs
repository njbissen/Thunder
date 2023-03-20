using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thunder
{
	public static class Extensions
	{
		public static double GetDistance(this Node source, Node destination)
		{
			int x = Math.Abs(source.X - destination.X);
			int y = Math.Abs(source.Y - destination.Y);
			return Math.Sqrt(y * y + x * x);
		}
	}
}
