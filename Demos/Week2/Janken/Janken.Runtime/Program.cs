using System;

using Janken.Runtime.Models;
using Janken.Runtime.Services;

namespace Janken.Runtime {
	internal class Program {
		private static readonly DataService Db = new DataService();
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
			Console.WriteLine("Welcome to Janken!\n");

			Player playerOne = Db.Players.GetComputer();
			Player playerTwo = playerOne;

			bool done = false;
			while (!done) {
				Console.WriteLine("[Main Menu]");
				Console.WriteLine("1 - Register Player");
				Console.WriteLine("2 - Player One Login");
				Console.WriteLine("3 - Player One Logout");
				Console.WriteLine("4 - Player Two Login");
				Console.WriteLine("5 - Player Two Logout");
				Console.WriteLine("6 - Play Game");
				Console.WriteLine("7 - Quit");

				switch (Console.ReadKey(true).Key) {
				case ConsoleKey.D1:
					RegisterPlayer();
					break;
				case ConsoleKey.D2:
					playerOne = LoginPlayer();
					break;
				case ConsoleKey.D3:
					playerTwo = LoginPlayer();
					break;
				case ConsoleKey.D4:
					playerOne = Db.Players.GetComputer();
					break;
				case ConsoleKey.D5:
					playerTwo = Db.Players.GetComputer();
					break;
				case ConsoleKey.D6:
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
