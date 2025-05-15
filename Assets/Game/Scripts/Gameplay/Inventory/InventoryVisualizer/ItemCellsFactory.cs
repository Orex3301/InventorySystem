using UnityEngine;
namespace Gameplay.Inventory
{
	public class ItemCellsFactory
	{
		private readonly FoodItemCell _foodCellPrefab;
		private readonly WeaponItemCell _weaponCellPrefab;
		private readonly UsableItemCell _usableItemCellPrefab;

		public ItemCellsFactory()
		{

		}

		public WeaponItemCell CreateWeaponCellForItem(IWeaponItem item, Transform holder)
		{
			WeaponItemCell cell = GameObject.Instantiate(_weaponCellPrefab, holder);
			cell.Item = item;
			return cell;
        }
        public FoodItemCell CreateFoodCellForItem(IFoodItem item, Transform holder)
		{
            FoodItemCell cell = GameObject.Instantiate(_foodCellPrefab, holder);
            cell.Item = item;
            return cell;
        }

		public UsableItemCell CreateUsableItemCellForItem(IUsableItem item, Transform holder)
		{
            UsableItemCell cell = GameObject.Instantiate(_usableItemCellPrefab, holder);
            cell.Item = item;
            return cell;
        }
	}
}