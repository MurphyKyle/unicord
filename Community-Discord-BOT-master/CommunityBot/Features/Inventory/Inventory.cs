using CommunityBot.Featires.Inventory;
using System;
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

		/// <summary>
		/// Default ctor
		/// </summary>
		public Inventory() { }
		
		/// <summary>
		/// Tries to add an item to the user's inventory from a JSON object
		/// </summary>
		/// <param name="hopefulJsonItem">Item details in JSON</param>
		/// <returns>bool indicating success or failure</returns>
		public bool AddToInv(string hopefulJsonItem)
		{
			// is in json format?
			if (CheckExistsNameDesc(hopefulJsonItem))
			{
				// yes - parse to an item
				Item newItem = new Item();
				Newtonsoft.Json.JsonConvert.PopulateObject(hopefulJsonItem, newItem);
			}
			else
			{
				// no - complain and do nothing

			}

			return false;
		}

		/// <summary>
		/// Tries to add an item to the user's inventory from a string array
		/// </summary>
		/// <param name="hopefulArrayItem">Item details separated in an array</param>
		/// <returns>bool indicating success or failure</returns>
		public bool AddToInv(string[] hopefulArrayItem)
		{
			if (CheckExistsNameDesc(hopefulArrayItem))
			{

			}
			else
			{
				// complain and do nothing

			}

			return false;
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


		public List<Item> Itams
		{
			get { return itams; }
			set { itams = value; }
		}
	}
}
