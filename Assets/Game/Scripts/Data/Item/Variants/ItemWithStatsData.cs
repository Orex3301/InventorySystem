using Inventory.InventoryVisualizer;
using System;
using UnityEngine;

namespace Data.Item
{
    [Serializable]
    public class ItemWithStatsData : ItemData
    {
        public string Stats { get; protected set; }
        public ItemStatsData ItemStatsData { get; protected set; }

        private readonly string _originName;

        public ItemWithStatsData(string name, string description, Sprite icon) : base(name, description, icon)
        {
            Name = _originName = name;
            Description = description;
            Icon = icon;
            Stats = string.Empty;
            ItemStatsData = new ItemStatsData(this);
        }

        public void ChangeName(string name)
        {
            if (name != string.Empty) Name = name;
            else Name = _originName;
        }

        public void ChangeStats(string stats) => Stats = stats;
    }
}