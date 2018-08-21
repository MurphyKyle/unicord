using CommunityBot.Featires.Inventory;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.Inventory
{
	/// <summary>
	/// All inventory data and helper methods go here
	/// </summary>
	public class Inventory
	{
		private List<Item> itams = new List<Item>();

		public List<Item> Itams
		{
			get { return itams; }
			private set { itams = value; }
		}

		public int Size
		{
			get { return Itams.Count; }
		}
		/// <summary>
		/// Default ctor
		/// </summary>
		public Inventory() { }

		public Inventory(List<Item> itams)
		{
			Itams = itams;
		}

		/// <summary>
		/// Tries to add an item to the user's inventory with attributes from an array
		/// </summary>
		/// <param name="name">Item name</param>
		/// <param name="description">Item description</param>
		/// <param name="attributes">String array of the item attributes (attName:attValue format)</param>
		/// <returns>bool indicating success or failure</returns>
		public bool AddToInv(string name, string description, IEnumerable<string> attributes)
		{
			Dictionary<string, string> atts = new Dictionary<string, string>();
			AddAttributeArrayToDictionary(attributes, atts);
			Itams.Add(new Item(name, description, atts));
			return true;
		}

		/// <summary>
		/// Tries to add an item to the user's inventory without any attributes
		/// </summary>
		/// <param name="name"></param>
		/// <param name="description"></param>
		/// <returns>bool indicating success or failure</returns>
		public bool AddToInv(string name, string description)
		{
			Itams.Add(new Item(name, description));
			return true;
		}

		/// <summary>
		/// Tries to add an item to the user's inventory from a string array
		/// </summary>
		/// <param name="hopefulArrayItem">Item details separated in an array</param>
		/// <returns>bool indicating success or failure</returns>
		public bool AddToInv(string[] hopefulArrayItem)
		{
			

			return false;
		}
		
		public void Clear()
		{
			Itams.Clear();
		}

		public Item[] GetItemByName(string name)
		{
			return Itams.Where(x => x.Name.Equals(name)).ToArray();
		}

		public bool DeleteItemByName(string name)
		{
			Item[] itms = GetItemByName(name);
			Itams.RemoveAll(x => x.Name.Equals(name));
			return true;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			foreach (Item itam in Itams)
			{
				sb.Append($"{itam.ToString()}\n");
			}

			return sb.ToString();
		}

		private void AddAttributeArrayToDictionary(IEnumerable<string> attributeAry, Dictionary<string, string> dict)
		{
			foreach (string att in attributeAry)
			{
				string[] attKeyVal = att
					.ToLowerInvariant()
					.Trim(',')
					.Split(":");
				dict.Add(attKeyVal[0].Trim(), attKeyVal[1].Trim());
			}
		}

		public static string PrintItems(IEnumerable<string> collection)
		{
			string s = "";
			foreach (string itam in collection)
			{
				s += $"{itam.ToString()}\n";
			}

			return s;
		}

		public bool UpdateItem(string name, IEnumerable<string> updates)
		{
			// find items
			Item[] itms = GetItemByName(name);

			if (itms.Length == 0)
			{
				return false;
			}

			List<string> removeKeyList = new List<string>();

			// swap updates to dictionary
			Dictionary<string, string> updateDict = new Dictionary<string, string>();
			AddAttributeArrayToDictionary(updates, updateDict);

			// check for name update
			bool hasName = updateDict.ContainsKey("name");
			// check for description update
			bool hasDesc = updateDict.ContainsKey("description");
			string newName = null;
			string newDesc = null;

			if (hasName)
			{
				newName = updateDict["name"];
				updateDict.Remove("name");
			}

			if (hasDesc)
			{
				newDesc = updateDict["description"];
				updateDict.Remove("description");
			}

			// update all found items ? sure!
			foreach (Item itm in itms)
			{
				if (hasName) { itm.Name = newName; }

				if (hasDesc) { itm.Description = newDesc; }

				// check rest of attributes
				foreach (string attKey in updateDict.Keys)
				{
					// attribute exists
					if (itm.Attributes.ContainsKey(attKey))
					{
						// update attribute value
						string newVal = updateDict[attKey];

						if (string.IsNullOrEmpty(newVal.Trim()))
						{
							removeKeyList.Add(attKey);
							itm.Attributes.Remove(attKey);
						}
						else
						{
							itm.Attributes[attKey] = updateDict[attKey];
						}
					}
					else
					{
						// attribute doesn't exist
						// add attribute/val
						if (removeKeyList.Contains(attKey))
						{
							itm.Attributes.Add(attKey, updateDict[attKey]);
						}
					}
				} // updated/added attributes
			} // end loop

			return true;
		} // end update item



	}
}
