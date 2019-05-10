using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqChallenge5.BishopMoves
{
	class Program
	{
		static void Main(string[] args)
		{
			// Problem: What positions can a bishop reach in a single move?

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

			Console.WriteLine("\nSolution 1");
			foreach ((char col, int row) in validMoves)
			{
				Console.WriteLine((col, row));
			}

			// Solution 2:

			IEnumerable<string> validMoves2 = Enumerable.Range('a', 8)
				.SelectMany(pos => Enumerable.Range(1, 8), (c, r) => (col: (char)c, row: r)) // created board tiles as (column, row) tuples
				.Where(pos => Math.Abs(pos.col - 'c') == Math.Abs(pos.row - 6))
				.Where(pos => pos.col != 'c')
				.Select(pos => $"{pos.col}{pos.row}");

			Console.WriteLine("\nSolution 2");
			foreach (string move in validMoves2)
			{
				Console.WriteLine(move);
			}

			// Solution 3:

			IEnumerable<(char col, int row)> validMoves3 = GetBoardPositions()
				.Where(p => BishopCanMoveTo(('c', 6), p));

			Console.WriteLine("\nSolution 3");
			foreach ((char col, int row) in validMoves3)
			{
				Console.WriteLine((col, row));
			}
		}

		/// <summary>
		/// Generates chess board tiles as (column, row) tuples
		/// </summary>
		/// <returns></returns>
		static IEnumerable<(char col, int row)> GetBoardPositions() => Enumerable.Range('a', 8)
				.SelectMany(x => Enumerable.Range(1, 8), (c, r) => (col: (char)c, row: r));

		/// <summary>
		/// Determines whether a Bishop can move from a given position to another
		/// </summary>
		/// <param name="startingPosition"></param>
		/// <param name="targetLocation"></param>
		/// <returns></returns>
		static bool BishopCanMoveTo((char col, int row) startingPosition, (char col, int row) targetLocation)
		{
			int dx = Math.Abs(targetLocation.col - startingPosition.col);  // calculate column offset
			int dy = Math.Abs(targetLocation.row - startingPosition.row);  // calculate row offset
			return dx == dy && dx != 0;  // filter the 'diagonals' and exclude current position
		}
	}
}
