using System.Collections.Generic;

namespace Gameplay.Inventory
{
    public class InventoryData 
    {
        public event System.Action WeaponAdded;
        public event System.Action UsableItemAdded;
        public event System.Action FoodAdded;

        private List<IWeaponItem> _weapons;
        private List<IUsableItem> _usables;
        private List<IFoodItem> _foods;

        public IReadOnlyList<IWeaponItem> GetWeapons()
            => _weapons;
        public IReadOnlyList<IUsableItem> GetUsables()
            => _usables;
        public IReadOnlyList<IFoodItem> GetFoods()
            => _foods;
        public void AddWeapon(IWeaponItem weapon)
        {
            _weapons.Add(weapon);
            WeaponAdded?.Invoke();
        }
        public void AddUsableItem(IUsableItem item)
        {
            _usables.Add(item);
            UsableItemAdded?.Invoke();
        }
        public void AddFood(IFoodItem food)
        {
            _foods.Add(food);
            FoodAdded?.Invoke();
        }
    }
}
