using System;
using System.Collections.Generic;
using System.Json;
using System.Net.Http;

namespace HelloCSharpWeb
{
	public class HunterService
	{
		public const string ServiceUrl = "http://hunter.cardnex.us/";
		public const string ServiceUsername = "auth";
		public const string ServicePassword = "0r1z3d";

		public IEnumerable<dynamic> GetCardsForSet(string setName)
		{
			// Undocumented feature to fix "The input stream contains too many delimiter characters" exception.
			// See http://forums.asp.net/post/4845421.aspx
			// Shouldn't be needed anymore once JSON.NET support is added to HttpClient post-beta.
			System.Net.Http.Formatting.MediaTypeFormatter.SkipStreamLimitChecks = true;

			var clientHandler = new HttpClientHandler
			{
				Credentials = new System.Net.NetworkCredential(ServiceUsername, ServicePassword)
			};

			using(var client = new HttpClient(clientHandler))
			{
				client.BaseAddress = new Uri(ServiceUrl);

				string setUrlPath = String.Format("sets/{0}", Uri.EscapeUriString(setName));
				var response = client.GetAsync(setUrlPath).Result;
				response.EnsureSuccessStatusCode();

				var set = response.Content.ReadAsAsync<System.Json.JsonObject>().Result;
				var cards = set["cards"].ReadAs<JsonArray>();

				return cards;
			}
		}
	}
}
