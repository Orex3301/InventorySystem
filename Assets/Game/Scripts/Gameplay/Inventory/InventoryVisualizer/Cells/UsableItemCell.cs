namespace Gameplay.Inventory
{
	public class UsableItemCell : ItemCell
	{
        private UsableItemInfoMenu _infoMenu;
        public IUsableItem Item
        {
            get { return _item; }
            set
            {
                _item = value;
                _icon.sprite = _item.Icon;
            }
        }

        private IUsableItem _item;

        private void Awake()
        {

        }
    }
}