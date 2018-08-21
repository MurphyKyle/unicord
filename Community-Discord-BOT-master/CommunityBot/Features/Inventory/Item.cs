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
		/// Creates an item without any attributes given
		/// </summary>
		/// <param name="name">Item name</param>
		/// <param name="description">Item description</param>
		public Item(string name, string description)
		{
			Name = name.Trim(',');
			Description = description.Trim(',');
		}

		/// <summary>
		/// Creates an item with all available fields
		/// </summary>
		/// <param name="name">Item name</param>
		/// <param name="description">Item description</param>
		/// <param name="atts">Item's attributes</param>
		public Item(string name, string description, Dictionary<string, string> atts)
		{
			Name = name.Trim(',');
			Description = description.Trim(',');
			Attributes = atts;
		}



		#region Properties
		public Dictionary<string, string> Attributes
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
		#endregion

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append($"Name = {Name}\n");
			sb.Append($"\tDescription = {Description} \n");
			sb.Append($"\tAttributes\n{Attributes.GetString()}");

			return sb.ToString();
		}

		public string ToJson()
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(this);
		}

	}


	public static class Extensions
	{
		public static string GetString(this Dictionary<string, string> dict)
		{
			StringBuilder sb = new StringBuilder();

			foreach (string key in dict.Keys)
			{
				sb.Append($"\t\t{key} = {dict[key]}\n");
			}
			return sb.ToString();
		}
	}
}
