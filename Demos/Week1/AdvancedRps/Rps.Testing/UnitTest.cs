using System;
using Xunit;

using Rps.Storage.Services;

namespace Rps.Testing {
	public class UnitTest {
		[Fact]
		public void Test() {
			TestingService service = new TestingService();
			Assert.NotNull(service);
		}
	}
}
