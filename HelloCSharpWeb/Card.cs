using System.Runtime.Serialization;

namespace HelloCSharpWeb
{
	[DataContract]
	public class Card
	{
		[DataMember]
		public string Name 
		{ get; protected set; }

		[DataMember]
		public string Color 
		{ get; protected set; }

		public Card(string name, string color)
		{
			Name = name;
			Color = color;
		}
	}
}
