using UnityEngine;

namespace Data.Item
{
    public class ItemData
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public Sprite Icon { get; protected set; }

        public ItemData(string name, string description, Sprite icon)
        {
            Name = name;
            Description = description;
            Icon = icon;
        }
    }
}
