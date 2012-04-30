using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HelloCSharpWeb.Web.Controllers
{
	public class SubtypeController : ApiController
	{
		public IEnumerable<Card> Get(string subtype)
		{
			var innistradBlockSets = new[]
			{
				"Innistrad",
				"Dark Ascension",
				"Avacyn Restored",
			};

			var hunter = new HunterService();

			return innistradBlockSets
				.AsParallel()
				.SelectMany(setName => hunter.GetCardsForSet(setName))
				.Where(c => c.compactType != null)
				.Where(c => ((string)c.compactType).ToLower().Contains((subtype ?? String.Empty).ToLower()))
				.Select(c => new Card((string)c.checklistName, (string)c.checklistColor));
		}
	}
}