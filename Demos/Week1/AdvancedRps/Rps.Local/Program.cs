using System;

using Rps.Storage.Models;
using Rps.Storage.Services;

namespace Rps.Local {
	internal enum Move {
		Rock = 1,
		Paper,
		Scissors
	}
	internal class Program {
		private static readonly ConsoleService db = new ConsoleService();
		public static void RunGame() {
			// Blah blah blah
		}
		public static void Main(string[] args) {
			Console.WriteLine("Welcome to Rock-Paper-Scissors Advanced!\n");

			while (true) {
				RunGame();

				Console.WriteLine("Continue playing? (Y/N)");
				ConsoleKeyInfo k = Console.ReadKey(true);
				if (k.KeyChar != 'y') break;
			}
			Console.WriteLine("Goodbye!");
		}
	}
}
