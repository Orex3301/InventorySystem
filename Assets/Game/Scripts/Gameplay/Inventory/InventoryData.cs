using System.Collections.Generic;

namespace Gameplay.Inventory
{
    public class InventoryData 
    {
        public event System.Action WeaponsChanged;
        public event System.Action UsableItemsChanged;
        public event System.Action FoodsChanged;

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
            WeaponsChanged?.Invoke();
        }
        public void AddUsableItem(IUsableItem item)
        {
            _usables.Add(item);
            UsableItemsChanged?.Invoke();
        }
        public void AddFood(IFoodItem food)
        {
            _foods.Add(food);
            FoodsChanged?.Invoke();
        }
        public void RemoveWeapon(IWeaponItem weapon)
        {
            _weapons.Remove(weapon);
            WeaponsChanged?.Invoke();
        }
        public void RemoveFod(IFoodItem food)
        {
            _foods.Remove(food);
            FoodsChanged?.Invoke();
        }
        public void RemoveUsableItem(IUsableItem item)
        {
            _usables.Remove(item);
            UsableItemsChanged?.Invoke();
        }
    }
}
