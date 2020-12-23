using System;
using Xunit;

using Janken.Domain.Models;
using Janken.Testing.Services;

namespace Janken.Testing {
	public class UnitTest {
		[Fact]
		public void Test() {
			DataService db = new DataService();
			Player computer = db.Players.GetComputer();
			Assert.NotNull(computer);
		}
	}
}
