using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpotThePattern4.TransformingObjects
{
	class Program
	{
		// Objective: turn an array of file paths into a list of file sizes.
		static List<long> GetListOfFileSizes(IEnumerable<string> paths)
		{
			List<long> fileSizes = new List<long>();
			foreach (string path in paths)
			{
				long length = new FileInfo(path).Length;
				fileSizes.Add(length);
			}
			return fileSizes;
		}

		static void Main(string[] args)
		{
			string[] paths = new[] { "c:\\Windows\\notepad.exe", "c:\\Windows\\regedit.exe", "c:\\Windows\\explorer.exe" };

			GetListOfFileSizes(paths).ForEach(Console.WriteLine);

			// Using LINQ:

			// Turn an array of file paths into a list of file sizes and print it
			paths.Select(p => new FileInfo(p).Length)
				.ToList()
				.ForEach(Console.WriteLine);

			// Turn an array of file paths into a dictionary, then print the dictionary
			paths.Select(s => new FileInfo(s))
				.ToDictionary(fi => fi.Name, fi => fi.Length)
				.Select(kvp => $"{kvp.Key} : {kvp.Value}")
				.ToList()
				.ForEach(Console.WriteLine);
		}
	}
}
