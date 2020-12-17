using System;
using System.ComponentModel.DataAnnotations;

using Rps.Domain.Abstracts;

namespace Rps.Domain.Models {
	public class Round : AModel {
		[Key]
		public int ID { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime EndDate { get; set; }
		[Required]
		public int WinnerID { get; set; }
		[Required]
		public int LoserID { get; set; }
#region NAVIGATIONAL PROPERTIES
		public Player Winner { get; set; }
		public Player Loser { get; set; }
#endregion // NAVIGATIONAL PROPERTIES
		public override int GetID() {
			return ID;
		}
	}
}
