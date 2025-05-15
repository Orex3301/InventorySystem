using UnityEngine;

namespace Gameplay.Inventory
{
	public class InventoryWindow : MonoBehaviour
	{
        [field: SerializeField] public Transform WeaponsContentHolder { get; private set; }
        [field: SerializeField] public Transform FoodsContentHolder { get; private set; }
        [field: SerializeField] public Transform UsableItemsContentHolder { get; private set; }

		public event System.Action Destroyed;

        public void ShowWeapons()
        {
            WeaponsContentHolder.gameObject.SetActive(true);
            FoodsContentHolder.gameObject.SetActive(false);
            UsableItemsContentHolder.gameObject.SetActive(false);
        }

        public void ShowFoods()
        {
            WeaponsContentHolder.gameObject.SetActive(false);
            FoodsContentHolder.gameObject.SetActive(true);
            UsableItemsContentHolder.gameObject.SetActive(false);
        }

        public void ShowUsableItems()
        {
            WeaponsContentHolder.gameObject.SetActive(false);
            FoodsContentHolder.gameObject.SetActive(false);
            UsableItemsContentHolder.gameObject.SetActive(true);
        }

        public void Hide()
        {
            WeaponsContentHolder.gameObject.SetActive(false);
            FoodsContentHolder.gameObject.SetActive(false);
            UsableItemsContentHolder.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke();
        }
    }
}