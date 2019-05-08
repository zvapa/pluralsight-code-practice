using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqChallenge3.RangeExpansion
{
	class Program
	{
		static void Main(string[] args)
		{
			// Objective 1: Expand the range (sorted)
			// e.g.: "2,3-5,7" should expand to 2,3,4,5,7

			string rangeToExpand = "2,5,7-10,11,17-18";

			IEnumerable<int> result = rangeToExpand
							.Split(',')
							.Select(s => s.Contains('-')
											? s.Split('-')
											: new string[] { s, s })
							.SelectMany(sa => Enumerable.Range(int.Parse(sa[0]), int.Parse(sa[1]) - int.Parse(sa[0]) + 1));

			// alternatively:
			IEnumerable<int> alt_result = rangeToExpand
							.Split(',')
							.Select(x => x.Split('-'))
							.Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
							.SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1));

			Console.WriteLine(result);

			// Objective 2: Expand the range (unsorted, overlapping)
			// e.g.: "6,1-3,2-4" should expand to 1,2,3,4,6

			string rangeToExpand2 = "6,1-3,2-4";

			IEnumerable<int> result2 = rangeToExpand2
							.Split(',')
							.Select(x => x.Split('-'))
							.Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
							.SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1))
							.OrderBy(r => r)
							.Distinct();
		}
	}
}
