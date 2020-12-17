using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Rps.Storage.Abstracts;

namespace Rps.Storage.Models {
	public class Round : AModel {
		[Key]
		public int RoundID { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime EndDate { get; set; }
		[Required]
		public bool Draw { get; set; }
		[ForeignKey("Winner")]
		public int WinnerID { get; set; }
		public Player Winner { get; set; }
		[ForeignKey("Loser")]
		public int LoserID { get; set; }
		public Player Loser { get; set; }
		public override int GetID() {
			return RoundID;
		}
	}
}
