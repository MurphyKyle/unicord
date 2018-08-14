using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CommunityBot.Entities
{
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
		public Item(string jsonHopeful)
		{
			// is in json format?
			if (CheckExistsNameDesc(jsonHopeful))
			{
				// yes - parse to an item

			}
			else
			{
				// no - complain and do nothing

			}

		}

		/// <summary>
		///  Item Format == {name, description, attKey1:attVal1, attKey2:attVal2 etc...}
		/// </summary>
		/// <param name="itemFormatHopeful"></param>
		public Item(params string[] itemFormatHopeful)
		{
			if (CheckExistsNameDesc(itemFormatHopeful))
			{

			}
			else
			{
				// complain and do nothing

			}
		}


		private bool CheckExistsNameDesc(string itemHopeful)
		{
			return itemHopeful.Contains("name") && itemHopeful.Contains("description");
		}

		private bool CheckExistsNameDesc(string[] itemHopeful)
		{
			// length MUST be AT LEAST 2, for name and description
			return itemHopeful.Length >= 2;
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
