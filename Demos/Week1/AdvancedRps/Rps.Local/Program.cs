using System;

using Rps.Storage.Models;
using Rps.Storage.Services;

namespace Rps.Local {
	internal enum Move {
		Invalid = 0,
		Rock = 1,
		Paper = 2,
		Scissors = 3
	}
	internal class Program {
		private static readonly LocalService DB = new LocalService();
		public static Move GetMove(Player player) {
			Move result = Move.Invalid;
			if (player.Computer) {
				Random rngsus = new Random();
				result = (Move)rngsus.Next(1, 3);
			}
			while (result == Move.Invalid) {
				Console.WriteLine($"{player.Handle}, choose your move: ");
				Console.WriteLine("1 - Rock");
				Console.WriteLine("2 - Paper");
				Console.WriteLine("3 - Scissors");
				ConsoleKeyInfo k = Console.ReadKey(true);
				switch (k.Key) {
				case ConsoleKey.D1:
					result = Move.Rock;
					break;
				case ConsoleKey.D2:
					result = Move.Paper;
					break;
				case ConsoleKey.D3:
					result = Move.Scissors;
					break;
				default:
					Console.WriteLine("Invalid key pressed!");
					break;
				}
			}
			return result;
		}
		public static Round RunRound(Player left, Player right) {
			Round result = new Round();
			result.StartDate = DateTime.Now;

			Move leftMove = GetMove(left);
			Move rightMove = GetMove(right);

			Console.WriteLine($"Player \"{left.Handle}\" chose {nameof(leftMove)}");
			Console.WriteLine($"Player \"{right.Handle}\" chose {nameof(rightMove)}");

			if (leftMove == rightMove) {
				result.Draw = true;
			} else {
				switch (leftMove) {
				case Move.Rock:
					if (rightMove == Move.Paper) {
						Console.WriteLine("Paper beats rock!");
						result.Winner = right;
						result.Loser = left;
					} else {
						Console.Write("Rock beats scissors!");
						result.Winner = left;
						result.Loser = right;
					}
					break;
				case Move.Paper:
					if (rightMove == Move.Rock) {
						Console.Write("Paper beats rock!");
						result.Winner = left;
						result.Loser = right;
					} else {
						result.Winner = right;
						result.Loser = left;
						Console.Write("Scissors beats paper!");
					}
					break;
				case Move.Scissors:
					if (rightMove == Move.Rock) {
						result.Winner = right;
						result.Loser = left;
						Console.Write("Rock beats scissors!");
					} else {
						result.Winner = left;
						result.Loser = right;
						Console.Write("Scissors beats paper!");
					}
					break;
				default:
					break;
				}
			}
			if (result.Draw) {
				Console.WriteLine("It's a draw!");
			}
			else {
				Console.WriteLine($"{result.Winner} wins!");
				Console.WriteLine($"{result.Loser} loses!");
			}
			result.EndDate = DateTime.Now;
			return result;
		}
		public static void Main(string[] args) {
			Console.WriteLine("Welcome to Rock-Paper-Scissors Advanced!\n");
			while (true) {
				// Run Game
				Console.WriteLine("Continue playing? (Y/N)");
				ConsoleKeyInfo k = Console.ReadKey(true);
				if (k.Key != ConsoleKey.Y) break;
			}
			Console.WriteLine("Goodbye!");
		}
	}
}
