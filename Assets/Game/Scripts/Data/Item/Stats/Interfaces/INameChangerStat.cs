namespace Data.Item.Stats
{
    public interface INameChangerStat : IItemStat
    {
        public string GetChangedName(string name);
    }
}
