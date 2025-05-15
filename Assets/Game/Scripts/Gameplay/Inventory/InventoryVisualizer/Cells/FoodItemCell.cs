namespace Gameplay.Inventory
{
	public class FoodItemCell : ItemCell
	{
        private FoodInfoMenu _infoMenu;
        public IFoodItem Item
        {
            get { return _item; }
            set
            {
                _item = value;
                _icon.sprite = _item.Icon;
            }
        }

        private IFoodItem _item;

        private void Awake()
        {

        }
    }
}