using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Inventory
{
    public class InventoryVisualizer<TItem> 
        where TItem : IInventoryItem 
    {
        private readonly Inventory<TItem> _inventory;
        private readonly InventoryWindow _window;
        private readonly ItemCellsFactory _itemCellsFactory;

        private List<ItemCell<TItem>> _cells;

        [Inject]
        public InventoryVisualizer(Inventory<TItem> inventory, ItemCellsFactory itemCellsFactory, InventoryWindow inventoryWindow)
        {
            _inventory = inventory;
            _itemCellsFactory = itemCellsFactory;
            _window = inventoryWindow;
            _cells = new();

            Subscribe();
        }

        public void Subscribe()
        {
            _inventory.ItemsChanged += OnItemsChanged;
            _window.Destroyed += Unsubscribe;
        }

        public void Unsubscribe()
        {
            _inventory.ItemsChanged -= OnItemsChanged;
            _window.Destroyed -= Unsubscribe;
        }

        public void ShowItems()
            => _window.ShowCells<TItem>();

        public void Hide()
            => _window.Hide();

        private void OnItemsChanged()
        {
            IReadOnlyList<TItem> items = _inventory.GetItems();
            Transform windowContent = _window.GetContentHolder<TItem>();

            int itemsInInventory = items.Count;
            int itemsOnScreen = _cells.Count;
            int maxItems = Mathf.Max(itemsInInventory, itemsOnScreen);

            for (int i = 0; i < maxItems; i++)
            {
                if (i < itemsOnScreen && i < itemsInInventory)
                {
                    _cells[i].Item = items[i];
                }
                else if (i >= itemsOnScreen)
                {
                    ItemCellObject cellObject = _itemCellsFactory.CreateCellObject(windowContent);
                    ItemCell<TItem> cell = new ItemCell<TItem>(cellObject);
                    cell.Item = items[i];
                    _cells.Add(cell);
                }
                else if (i >= itemsInInventory)
                {
                    _cells[i].Destroy();
                    _cells.RemoveAt(i);
                }
            }
        }
    }
}
