using System;

namespace RpsGame_NoDB {
	internal class Program {
		public static string GetMoveName(int move) {
			switch (move) {
				case 1: return "Rock";
				case 2: return "Paper";
				case 3: return "Scissors";
				default: return "Error";
			}
		}
		public static void PlayGame() {
			// Show Move Menu
			Console.Write("Your move:\n");
			Console.Write("1 - Rock\n");
			Console.Write("2 - Paper\n");
			Console.Write("3 - Scissors\n\n");

			// Get player's move from key press
			int playerMove = 0;
			while (playerMove == 0) {
				ConsoleKeyInfo k = Console.ReadKey();
				switch (k.KeyChar) {
					case '1':
						playerMove = 1;
						break;
					case '2':
						playerMove = 2;
						break;
					case '3':
						playerMove = 3;
						break;
					default:
						Console.Write("\b\bInvalid key pressed!\n");
						Console.Write("Please choose 1 (Rock), 2 (Paper), or 3 (Scissors)!\n\n");
						break;
				}
			}

			// Confirm player's move by printing it to console
			string playerMoveName = GetMoveName(playerMove);
			Console.Write($"\b\bYou chose {playerMoveName}!\n\n");

			// Generate opponent's move via praying to RNGsus
			Random rng = new Random();
			int opponentMove = rng.Next(1, 3);
			string opponentMoveName = GetMoveName(opponentMove);
			Console.Write($"Your opponent chose {opponentMoveName}!\n\n");

			// Compare moves
			if (playerMove == opponentMove) {
				Console.Write("It's a tie!\n\n");
			} else {
				switch (playerMove) {
					case 1: // Rock
						if (opponentMove == 2) {
							Console.Write("Paper beats rock! You Lose!\n\n");
						} else if (opponentMove == 3) {
							Console.Write("Rock beats scissors! You Win!\n\n");
						}
						break;
					case 2: // Paper
						if (opponentMove == 1) {
							Console.Write("Paper beats rock! You Win!\n\n");
						} else if (opponentMove == 3) {
							Console.Write("Scissors beats paper! You Lose!\n\n");
						}
						break;
					case 3: // Scissors
						if (opponentMove == 1) {
							Console.Write("Rock beats scissors! You Lose!\n\n");
						} else if (opponentMove == 2) {
							Console.Write("Scissors beats paper! You Win!\n\n");
						}
						break;
					default:
						break;
				}
			}
		}
		public static void Main(string[] args) {
			// Introduce Game
			Console.Write("Welcome to Rock-Paper-Scissors!\n\n");

			// Play until the player says "stop"
			while (true) {
				PlayGame();

				Console.Write("Continue playing? (y/n)\n");
				ConsoleKeyInfo k = Console.ReadKey();
				if (k.KeyChar != 'y') {
					break;
				}
				Console.Write("\b\b");
			}
			Console.Write("\b\bGoodbye!\n");
		}
	}
}
