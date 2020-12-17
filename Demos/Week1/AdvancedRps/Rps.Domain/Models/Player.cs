using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Rps.Domain.Abstracts;

namespace Rps.Domain.Models {
	public class Player : AModel {
		[Key]
		public int ID { get; set; }
		[Required]
		public string Handle { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool Computer { get; set; }
		[ForeignKey("WinnerID")]
		public ICollection<Round> Wins { get; set; }
		[ForeignKey("LoserID")]
		public ICollection<Round> Losses { get; set; }
		public override int GetID() {
			return ID;
		}
	}
}
