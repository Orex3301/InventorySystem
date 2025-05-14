using Data.Item.Stats;
using System;
using System.Collections.Generic;

namespace Data.Item
{
    [Serializable]
    public class ItemStatsData
    {
        public List<INameChangerStat> NameChangers { get; private set; }
        public List<IItemEffectStat> Effects { get; private set; }

        private readonly ItemWithStatsData _itemData;

        public ItemStatsData(ItemWithStatsData itemData)
        {
            _itemData = itemData;
        }

        public void AddStat(IItemStat stat)
        {
            if (stat is INameChangerStat)
            {
                NameChangers.Add(stat as INameChangerStat);
                _itemData.ChangeName(NameStatsCombiner.Combine(NameChangers));
            }
            if (stat is IItemEffectStat)
            {
                Effects.Add(stat as IItemEffectStat);
                _itemData.ChangeStats(EffectStatsCombiner.Combine(Effects));
            }
        }
    }
}
