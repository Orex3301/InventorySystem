using System.Collections.Generic;

namespace Data.Item.Stats
{
    public static class EffectStatsCombiner
    {
        public static string Combine(List<IItemEffectStat> effects)
        {
            string stats = string.Empty;

            foreach (IItemEffectStat effect in effects)
            {
                stats += effect.GetEffectString() + "\n";
            }

            return stats;
        }
    }
}
