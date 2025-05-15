using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Inventory
{
    public class InventoryVisualizer
    {
        private readonly InventoryData _inventory;
        private readonly InventoryWindow _window;
        private readonly ItemCellsFactory _itemCellsFactory;

        private  List<WeaponItemCell> _weaponCells;
        private List<FoodItemCell> _foodCells;
        private List<UsableItemCell> _usableItemCells;

        public InventoryVisualizer(InventoryData inventory, InventoryWindow window, ItemCellsFactory itemCellsFactory)
        {
            _inventory = inventory;
            _window = window;
            _itemCellsFactory = itemCellsFactory;
            Subscribe();
        }

        public void Subscribe()
        {
            _inventory.WeaponsChanged += OnWeaponChanged;
            _inventory.FoodsChanged += OnFoodChanged;
            _inventory.UsableItemsChanged += OnUsableItemChanged;
            _window.Destroyed += Unsubscribe;
        }

        public void Unsubscribe()
        {
            _inventory.WeaponsChanged -= OnWeaponChanged;
            _inventory.FoodsChanged -= OnFoodChanged;
            _inventory.UsableItemsChanged -= OnUsableItemChanged;
            _window.Destroyed -= Unsubscribe;
        }

        public void ShowWeapons()
            => _window.ShowWeapons();
        public void ShowUsableItems()
            => _window.ShowUsableItems();
        public void ShowFoods()
            => _window.ShowFoods();
        public void Hide()
            => _window.Hide();

        private void OnWeaponChanged()
        {
            IReadOnlyList<IWeaponItem> items = _inventory.GetWeapons();
            Transform windowContent = _window.WeaponsContentHolder;

            int weaponsInInventory = items.Count;
            int weaponsOnScreen = _weaponCells.Count;
            int maxItems = Mathf.Max(weaponsInInventory, weaponsOnScreen);

            for (int i = 0; i < maxItems; i++)
            {
                if (i < weaponsOnScreen && i < weaponsInInventory)
                {
                    _weaponCells[i].Item = items[i];
                }
                else if (i >= weaponsOnScreen)
                {
                    WeaponItemCell cell = _itemCellsFactory.CreateWeaponCellForItem(items[i], windowContent);
                    _weaponCells.Add(cell);
                }
                else if (i >= weaponsInInventory)
                {
                    GameObject.Destroy(_weaponCells[i]);
                    _weaponCells.RemoveAt(i);
                }
            }
        }

        private void OnFoodChanged()
        {
            IReadOnlyList<IFoodItem> items = _inventory.GetFoods();
            Transform windowContent = _window.FoodsContentHolder;

            int foodsInInventory = items.Count;
            int foodsOnScreen = _foodCells.Count;
            int maxItems = Mathf.Max(foodsInInventory, foodsOnScreen);

            for (int i = 0; i < maxItems; i++)
            {
                if (i < foodsOnScreen && i < foodsInInventory)
                {
                    _foodCells[i].Item = items[i];
                }
                else if (i >= foodsOnScreen)
                {
                    FoodItemCell cell = _itemCellsFactory.CreateFoodCellForItem(items[i], windowContent);
                    _foodCells.Add(cell);
                }
                else if (i >= foodsInInventory)
                {
                    GameObject.Destroy(_foodCells[i]);
                    _foodCells.RemoveAt(i);
                }
            }
        }

        private void OnUsableItemChanged()
        {
            IReadOnlyList<IUsableItem> items = _inventory.GetUsables();
            Transform windowContent = _window.UsableItemsContentHolder;

            int usablesInInventory = items.Count;
            int usablesOnScreen = _usableItemCells.Count;
            int maxItems = Mathf.Max(usablesInInventory, usablesOnScreen);

            for (int i = 0; i < maxItems; i++)
            {
                if (i < usablesOnScreen && i < usablesInInventory)
                {
                    _usableItemCells[i].Item = items[i];
                }
                else if (i >= usablesOnScreen)
                {
                    UsableItemCell cell = _itemCellsFactory.CreateUsableItemCellForItem(items[i], windowContent);
                    _usableItemCells.Add(cell);
                }
                else if (i >= usablesInInventory)
                {
                    GameObject.Destroy(_usableItemCells[i]);
                    _usableItemCells.RemoveAt(i);
                }
            }
        }
    }
}
