﻿using System;
using System.Collections.Generic;

namespace CommunityBot.Entities
{
    public class GlobalUserAccount : IGlobalAccount
    {
        public GlobalUserAccount(ulong id)
        {
            Id = id;
        }

        public ulong Id { get; }

        public ulong Miunies { get; set; } = 1;

        public DateTime LastDaily { get; set; } = DateTime.UtcNow.AddDays(-2);
        
        public DateTime LastMessage { get; set; } = DateTime.UtcNow;

        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> Favorites { get; set; } = new Dictionary<string, string>();

        public List<ReminderEntry> Reminders { get; internal set; } = new List<ReminderEntry>();

		public Features.Inventory.Inventory Inv { get; set; } = new Features.Inventory.Inventory();
        /* Add more values to store */

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as IGlobalAccount);
        }

        // implementation for IEquatable
        public bool Equals(IGlobalAccount other)
        {
            return Id == other.Id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return unchecked((int)Id);
        }
    }

    public struct ReminderEntry
    {
        public DateTime DueDate;
        public string Description;

        public ReminderEntry(DateTime dueDate, string description)
        {
            DueDate = dueDate;
            Description = description;
        }
    }
}
