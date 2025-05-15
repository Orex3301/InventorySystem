using UnityEngine;

namespace Gameplay.Inventory
{
    public class ItemCell<T> : IItemCell where T : IInventoryItem
	{
		private ItemCellObject _cellObject;

		public T Item
		{
			get { return _item; }
			set 
			{
				_item = value;
				_cellObject.Icon.sprite = _item.Icon;
			}
		}

		private T _item;

		public ItemCell(ItemCellObject cellObject)
		{
			_cellObject = cellObject;
		}

		public void Destroy()
		{
			GameObject.Destroy(_cellObject);
		}

        public void OnCellClicked()
        {
            throw new System.NotImplementedException();
        }
    }
}