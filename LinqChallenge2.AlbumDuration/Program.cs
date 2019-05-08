using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LinqChallange2.AlbumDuration
{
	class Program
	{
		static void Main(string[] args)
		{
			// Given a string containing the lengths of each track in an album,
			// calculate how long the album of music is.

			string trackLengths = "2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24";

			TimeSpan tl = trackLengths.Split(',')
				.Select(s => TimeSpan.ParseExact(s, @"m\:ss", null))
				.Aggregate((runningTotal, timespan) => runningTotal + timespan);

			// alternative:

			double tl2 = trackLengths.Split(',')
				.Select(t => TimeSpan.Parse("0:" + t))
				.Select(t => t.TotalSeconds)
				.Sum();
			TimeSpan totalTime = TimeSpan.FromSeconds(tl2);

			Console.WriteLine(tl);
			Console.WriteLine(totalTime);
			

		}
	}
}
