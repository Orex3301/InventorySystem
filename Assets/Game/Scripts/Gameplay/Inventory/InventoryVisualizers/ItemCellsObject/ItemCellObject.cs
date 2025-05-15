using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Inventory
{
    public class ItemCellObject : MonoBehaviour
    {
        [field: SerializeField] public Image Icon { get; private set; }

        private IItemCell _itemCell;

        public void Initialize(IItemCell itemCell)
        {
            _itemCell = itemCell;
        }

        private void OnMouseDown()
        {
            _itemCell.OnCellClicked();
        }
    }
}
