using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloCSharpWeb.Test
{
	[TestClass]
	public class HunterServiceTest
	{
		[TestMethod]
		public void ReadsLiveData()
		{
			HunterService service = new HunterService();
			var result = service.GetCardsForSet("Avacyn Restored");

			Assert.IsNotNull(result);
			Assert.AreEqual(234, result.Count());
		}
	}
}
