using System.Collections.Generic;

namespace Data.Item.Stats
{
    public static class NameStatsCombiner
    {
        public static string Combine(List<INameChangerStat> stats)
        {
            string name = string.Empty;
            foreach (INameChangerStat stat in stats)
            {
                name = stat.GetChangedName(name);
            }
            return name;
        }
    }
}
