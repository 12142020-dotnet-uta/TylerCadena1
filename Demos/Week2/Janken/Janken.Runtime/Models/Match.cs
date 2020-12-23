using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Janken.Runtime.Models {
	public class Match : Model {
		[Key]
		public Guid MatchId { get; set; } = Guid.NewGuid();
		[Required]
		public Player PlayerA { get; set; }
		[Required]
		public Player PlayerB { get; set; }
		[Required]
		public List<Round> Rounds { get; set; }
		[Required]
		public DateTime StartTime { get; set; }
		[Required]
		public DateTime EndTime { get; set; }
		public Match() {}
		public Match(Player playerA, Player playerB) {
			PlayerA = playerA;
			PlayerB = playerB;
			Rounds = new List<Round>();
			StartTime = DateTime.Now;
		}
		/// <summary>
		/// Finds the winner of the match so far.
		/// </summary>
		/// <returns>
		/// Returns null if no rounds have been played, or if there is a tie.
		/// </returns>
		public Player GetWinner() {
			int playerAWins = 0, playerBWins = 0;
			foreach (var r in Rounds) {
				if (!r.IsDraw()) {
					if (r.Winner.PlayerId == PlayerA.PlayerId) {
						++playerAWins;
					} else if (r.Winner.PlayerId == PlayerB.PlayerId) {
						++playerBWins;
					}
				}
			}
			if (playerAWins == playerBWins) {
				return null;
			}
			return playerAWins > playerBWins ?
				PlayerA :
				PlayerB;
		}
		public override Guid GetId() => MatchId;
	}
}
