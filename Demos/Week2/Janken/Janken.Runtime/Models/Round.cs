using System;
using System.ComponentModel.DataAnnotations;

namespace Janken.Runtime.Models {

	public class Round : Model {
		[Key]
		public Guid RoundId { get; set; } = Guid.NewGuid();
		[Required]
		public Choice ChoiceA { get; set; }
		[Required]
		public Choice ChoiceB { get; set; }
		public Player Winner { get; set; }
		public Round() {}
		public Round(Player playerA, Choice choiceA, Player playerB, Choice choiceB) {
			ChoiceA = choiceA;
			ChoiceB = choiceB;

			ChoiceType choiceTypeA = choiceA.GetChoiceType();
			ChoiceType choiceTypeB = choiceB.GetChoiceType();

			switch (choiceTypeA) {
			case ChoiceType.Rock:
				if (choiceTypeB == ChoiceType.Paper) {
					Winner = playerB;
				} else if (choiceTypeB == ChoiceType.Scissors) {
					Winner = playerA;
				}
				break;
			case ChoiceType.Paper:
				if (choiceTypeB == ChoiceType.Rock) {
					Winner = playerA;
				} else if (choiceTypeB == ChoiceType.Scissors) {
					Winner = playerB;
				}
				break;
			case ChoiceType.Scissors:
				if (choiceTypeB == ChoiceType.Rock) {
					Winner = playerB;
				} else if (choiceTypeB == ChoiceType.Paper) {
					Winner = playerA;
				}
				break;
			default:
				break;
			}
		}
		/// <summary>
		/// Checks if round is a draw.
		/// </summary>
		public bool IsDraw() {
			return ChoiceA == ChoiceB;
		}
		public override Guid GetId() => RoundId;
	}
}
