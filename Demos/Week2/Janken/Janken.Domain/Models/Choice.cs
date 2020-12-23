using System;
using System.ComponentModel.DataAnnotations;

namespace Janken.Domain.Models {
	public enum ChoiceType {
		Invalid = 0,
		Rock = 1,
		Paper = 2,
		Scissors = 3
	}
	public class Choice : Model {
		[Key]
		public Guid ChoiceId { get; set; } = Guid.NewGuid();
		[Required]
		public string Name { get; set; }
		public int Value { get; set; }
		public Choice() : this(ChoiceType.Invalid) {}
		public Choice(ChoiceType type) {
			Name = nameof(type);
			Value = (int)(type);
		}
		/// <summary>
		/// Gets choice type from value.
		/// </summary>
		public ChoiceType GetChoiceType() {
			return (ChoiceType)Value;
		}
		/// <summary>
		/// Gets seeded data for the database, which contains all possible moves.
		/// </summary>
		/// <returns>
		/// Returns array of Choices.
		/// </returns>
		public static Choice[] GenerateSeededData() {
			Choice[] choices = new Choice[] {
				new Choice(),
				new Choice(ChoiceType.Rock),
				new Choice(ChoiceType.Paper),
				new Choice(ChoiceType.Scissors)
			};
			return choices;
		}
		public override Guid GetId() => ChoiceId;
	}
}
