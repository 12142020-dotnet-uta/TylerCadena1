using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Rps.Storage.Abstracts;

namespace Rps.Storage.Models {
	public class Player : AModel {
		[Key]
		public int PlayerID { get; set; }
		[Required]
		public string Handle { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool Computer { get; set; }
		public override int GetID() {
			return PlayerID;
		}
		public static Player[] GenerateSeededData() {
			Player[] players = new Player[] {
				new Player() {
					PlayerID = 1,
					Handle = "CPU",
					Password = "CPU",
					Computer = true
				}
			};
			return players;
		}
	}
}
