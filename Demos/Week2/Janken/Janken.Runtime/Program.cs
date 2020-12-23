using System;

using Janken.Runtime.Models;
using Janken.Runtime.Services;

namespace Janken.Runtime {
	internal class Program {
		private static readonly DataService Db = new DataService();
		private static readonly ChoiceService Rng = new ChoiceService();
		public static ChoiceType RunChoice(Player player) {
			if (player.Computer) {
				return Rng.GetChoice();
			}
			ChoiceType result = ChoiceType.Invalid;
			while (result == ChoiceType.Invalid) {
				Console.WriteLine("{0}, choose your move: ", player.Handle);
				Console.WriteLine("1 - Rock");
				Console.WriteLine("2 - Paper");
				Console.WriteLine("3 - Scissors");
				switch (Console.ReadKey(true).Key) {
				case ConsoleKey.D1:
					result = ChoiceType.Rock;
					break;
				case ConsoleKey.D2:
					result = ChoiceType.Paper;
					break;
				case ConsoleKey.D3:
					result = ChoiceType.Scissors;
					break;
				default:
					Console.WriteLine("Invalid key pressed!");
					break;
				}
			}
			return result;
		}
		public static Round RunRound(Player playerOne, Player playerTwo) {
			Choice choiceOne = Db.Choices.Get(RunChoice(playerOne));
			Choice choiceTwo = Db.Choices.Get(RunChoice(playerTwo));
			Console.WriteLine("\"{0}\" chose {1}!", playerOne.Handle, choiceOne.Name);
			Console.WriteLine("\"{0}\" chose {1}!", playerTwo.Handle, choiceTwo.Name);
			Round result = new Round(
				playerOne, choiceOne,
				playerTwo, choiceTwo
			);
			Console.WriteLine(result.GenerateMessage());
			if (!result.IsDraw()) {
				Console.WriteLine("{0} wins!", result.Winner);
			}
			return result;
		}
		public static void PlayGame(Player playerOne, Player playerTwo) {
			Match match = new Match(playerOne, playerTwo);
			match.StartTime = DateTime.Now;
			while (true) {
				if (match.Rounds.Count > 0) {
					Console.WriteLine(
						"{0}: {1} | {2}: {3}",
						playerOne.Handle,
						match.GetTallyForA(),
						playerTwo.Handle,
						match.GetTallyForB()
					);
				}
				Console.WriteLine("Round {0}!", match.Rounds.Count + 1);

				match.Rounds.Add(RunRound(playerOne, playerTwo));

				Console.Write("Continue? (Y/N)");
				if (Console.ReadKey(true).Key != ConsoleKey.Y) {
					break;
				}
			}
			match.EndTime = DateTime.Now;

			Console.WriteLine("[Results]");
			Console.WriteLine(
				"{0}: {1} | {2}: {3}",
				playerOne.Handle,
				match.GetTallyForA(),
				playerTwo.Handle,
				match.GetTallyForB()
			);
			Console.WriteLine("{0} wins the match!", match.GetWinner().Handle);

			foreach (var r in match.Rounds) {
				Db.Rounds.Create(r);
			}
			Db.Matches.Create(match);
		}
		public static string ReadPassword() {
			string password = "";
			while (true) {
				ConsoleKeyInfo k = Console.ReadKey(true);
				if (k.Key == ConsoleKey.Enter) {
					break;
				} else if (k.Key == ConsoleKey.Backspace) {
					if (password.Length > 0) {
						password = password.Remove(password.Length - 1);
						Console.Write("\b \b");
					}
				} else if (k.KeyChar != '\u0000') {
					password += k.KeyChar;
					Console.Write("*");
				}
			}
			return password;
		}
		public static Player LoginPlayer() {
			Console.WriteLine("What's your handle?");
			string handle = Console.ReadLine();
			string password = ReadPassword();
			Player result = Db.Players.GetByHandleAndPassword(handle, password);
			if (result != null) {
				Console.WriteLine("Welcome back, {0}!", handle);
				return result;
			}
			Console.WriteLine("Either your handle or your password are wrong!");
			return Db.Players.GetComputer();
		}
		public static void RegisterPlayer() {
			Console.Write("What's your handle gonna be?");
			string handle = "";
			while (handle.Length == 0) {
				handle = Console.ReadLine();
				if (Db.Players.HandleExists(handle)) {
					handle = "";
					Console.WriteLine("That handle already exists! Try another one.");
				}
			}
			Console.WriteLine("What's your password gonna be?");
			string password = ReadPassword();
			Player player = new Player(handle, password);
			if (Db.Players.Create(player)) {
				Console.WriteLine("Successfully registered {0}!", handle);
			} else {
				Console.WriteLine("Something went wrong! Sorry!");
			}
		}
		private static void Main(string[] args) {
			Player playerOne = Db.Players.GetComputer();
			Player playerTwo = playerOne;
			bool done = false;
			while (!done) {
				Console.WriteLine("[Janken]");
				Console.WriteLine("1 - Register Player");
				Console.WriteLine("2 - Player One Login");
				Console.WriteLine("3 - Player One Logout");
				Console.WriteLine("4 - Player Two Login");
				Console.WriteLine("5 - Player Two Logout");
				Console.WriteLine("6 - Start Match");
				Console.WriteLine("7 - Quit");
				switch (Console.ReadKey(true).Key) {
				case ConsoleKey.D1:
					RegisterPlayer();
					break;
				case ConsoleKey.D2:
					playerOne = LoginPlayer();
					break;
				case ConsoleKey.D3:
					playerOne = Db.Players.GetComputer();
					break;
				case ConsoleKey.D4:
					playerTwo = LoginPlayer();
					break;
				case ConsoleKey.D5:
					playerTwo = Db.Players.GetComputer();
					break;
				case ConsoleKey.D6:
					PlayGame(playerOne, playerTwo);
					break;
				case ConsoleKey.D7:
					Console.WriteLine("Goodbye!");
					done = true;
					break;
				default:
					Console.WriteLine("Invalid key pressed!");
					break;
				}
			}
		}
	}
}
