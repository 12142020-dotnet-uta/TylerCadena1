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
		/// Returns the tally for a particular player.
		/// </summary>
		private int GetTallyFor(Player player) {
			int result = 0;
			foreach (var r in Rounds) {
				if (!r.IsDraw()) {
					if (r.Winner.PlayerId == player.PlayerId) {
						++result;
					}
				}
			}
			return result;
		}
		public int GetTallyForA() => GetTallyFor(PlayerA);
		public int GetTallyForB() => GetTallyFor(PlayerB);
		/// <summary>
		/// Finds the winner of the match so far.
		/// </summary>
		/// <returns>
		/// Returns null if no rounds have been played, or if there is a tie.
		/// </returns>
		public Player GetWinner() {
			if (Rounds.Count == 0) {
				return null;
			}
			int playerAWins = GetTallyForA();
			int playerBWins = GetTallyForB();
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
