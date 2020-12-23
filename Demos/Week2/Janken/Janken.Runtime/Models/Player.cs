using System;
using System.ComponentModel.DataAnnotations;

namespace Janken.Runtime.Models {
	public class Player : Model {
		[Key]
		public Guid PlayerId { get; set; } = Guid.NewGuid();
		[Required]
		public string Handle { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool Computer { get; set; }
		public Player() {}
		public Player(string handle, string password) {
			Handle = handle;
			Password = password;
			Computer = false;
		}
		public override Guid GetId() => PlayerId;
		/// <summary>
		/// Gets seeded data for the database, which contains the computer player.
		/// </summary>
		/// <returns>
		/// Returns array of players.
		/// </returns>
		public static Player[] GenerateSeededData() {
			Player[] players = new Player[] {
				new Player() {
					PlayerId = Guid.NewGuid(),
					Handle = "",
					Password = "",
					Computer = true
				}
			};
			return players;
		}
	}
}
