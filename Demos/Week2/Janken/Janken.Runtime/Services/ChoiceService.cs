using System;

using Janken.Runtime.Models;

namespace Janken.Runtime.Services {
	public class ChoiceService {
		private Random Generator;
		public ChoiceService() {
			Generator = new Random(DateTime.Now.Millisecond);
		}
		public ChoiceType GetChoice() {
			int result = Generator.Next(1, 3);
			return (ChoiceType)result;
		}
	}
}
