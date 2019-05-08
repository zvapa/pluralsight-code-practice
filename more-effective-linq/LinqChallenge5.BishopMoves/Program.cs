using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqChallenge5.BishopMoves
{
	class Program
	{
		static void Main(string[] args)
		{
			// What positions can a bishop reach in a single move?

			// Objective: Create an enumerable sequence containing the names of 
			// each square a Bishop chess piece can move to in a single turn.
			// E.g.: if start with a Bishop on c6, output should be:
			// a4, a8, b5, b7, d5, d7, e4, e8, f3, g2, h1

			// Solution 1:

			// generate all board positions (a1, a2...h8)
			string cols = "abcdefgh";
			IEnumerable<char> letters = "abcdefgh".ToCharArray().SelectMany(c => Enumerable.Repeat(c, 8));
			IEnumerable<int> numbers = Enumerable.Range(1, 8).SelectMany(n => Enumerable.Range(1, 8));
			IEnumerable<(char col, int row)> board = letters.Zip(numbers, (letter, number) => (col: letter, row: number));

			(char col, int row) current = ('c', 6);

			IEnumerable<(char col, int row)> validMoves = board
				.Where(target => Math.Abs(cols.IndexOf(current.col) - cols.IndexOf(target.col)) == Math.Abs(current.row - target.row))
				.Where(target => target.col != current.col);

			foreach ((char col, int row) in validMoves)
			{
				Console.WriteLine((col, row));
			}

			// Alternative solution:

			IEnumerable<string> validMoves2 = Enumerable.Range('a', 8)
				.SelectMany(x => Enumerable.Range(1, 8), (c, r) => (col: (char)c, row: r))
				.Where(x => Math.Abs(x.col - 'c') == Math.Abs(x.row - 6))
				.Where(x => x.col != 'c')
				.Select(x => $"{x.col}{x.row}");

			foreach (string move in validMoves2)
			{
				Console.WriteLine(move);
			}
		}
	}
}
