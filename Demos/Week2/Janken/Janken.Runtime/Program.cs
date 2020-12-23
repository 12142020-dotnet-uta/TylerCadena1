using System;

using Janken.Runtime.Models;
using Janken.Runtime.Services;

namespace Janken.Runtime {
	internal class Program {
		private static void Main(string[] args) {
			DataService data = new DataService();
			Player computer = data.Players.GetComputer();
			Console.WriteLine("Hello, {0}!", computer.PlayerId);
		}
	}
}
