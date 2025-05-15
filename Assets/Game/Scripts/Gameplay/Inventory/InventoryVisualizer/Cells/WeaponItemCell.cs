namespace Gameplay.Inventory
{
	public class WeaponItemCell : ItemCell
	{
		private WeaponInfoMenu _infoMenu;
		public IWeaponItem Item
		{
			get { return _item; }
			set 
			{
				_item = value;
				_icon.sprite = _item.Icon;
			}
		}

		private IWeaponItem _item;

        private void Awake()
        {

        }
    }
}