using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CommunityBot.Featires.Inventory
{
	/// <summary>
	/// All item data and helper methods go here
	/// </summary>
	public class Item
	{

		private string name = "DABOT'S_ITAM";
		private string description = "iT haS 1337 MaGiKaL PowArz";
		private Dictionary<string, string> itemAttributes = new Dictionary<string, string>();

		/// <summary>
		/// Default constructor with the values:
		/// name		= "DABOT'S_ITAM"
		/// description = "iT haS 1337 MaGiKaL PowArz"
		/// </summary>
		public Item() { }

		/// <summary>
		/// JSON Format ==
		/// {
		/// "name": "John",
		/// "description": "Smith",
		/// "attributes": {
		///	"attKey1": "attVal1",
		///	"attKey2": "attVal2",
		///	"attKey3": "attVal3",
		///	}
		/// }
		/// </summary>
		/// <param name="jsonHopeful"></param>
		public Item(string jsonObj)
		{
			

		}

		/// <summary>
		///  Item Format == {name, description, attKey1:attVal1, attKey2:attVal2 etc...}
		/// </summary>
		/// <param name="itemFormatHopeful"></param>
		public Item(params string[] itemArray)
		{
			
		}		

		public Dictionary<string, string> ItemAttributes
		{
			get { return itemAttributes; }
			set { itemAttributes = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

	}
}
