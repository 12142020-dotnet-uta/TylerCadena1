using System;

namespace RpsGame_NoDB {
	internal class Program {
		public static void Main(string[] args) {
			Console.WriteLine("Welcome to Rock-Paper-Scissors!\n");
			Console.WriteLine("Your move:");
			Console.WriteLine("1 - Rock");
			Console.WriteLine("2 - Paper");
			Console.WriteLine("3 - Scissors\n");

			int userMove = 0;
			while (userMove == 0) {
				ConsoleKeyInfo k = Console.ReadKey();
				switch (k.KeyChar) {
					case '1':
						userMove = 1;
						break;
					case '2':
						userMove = 2;
						break;
					case '3':
						userMove = 3;
						break;
					default:
						Console.WriteLine("\b\bInvalid key pressed!");
						Console.WriteLine("Please choose 1 (Rock), 2 (Paper), or 3 (Scissors)!");
						break;
				}
			}

			Console.WriteLine($"\b\bYou chose {userMove}!");
		}
	}
}
