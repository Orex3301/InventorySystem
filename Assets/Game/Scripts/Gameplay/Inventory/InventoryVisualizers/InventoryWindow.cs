using UnityEngine;

namespace Gameplay.Inventory
{
	public class InventoryWindow : MonoBehaviour
	{
        [field: SerializeField] private Transform _weaponsContentHolder;
        [field: SerializeField] private Transform _foodsContentHolder;
        [field: SerializeField] private Transform _usableItemsContentHolder;

		public event System.Action Destroyed;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShowCells<T>() where T : IInventoryItem
        {
            gameObject.SetActive(true);
            _weaponsContentHolder.gameObject.SetActive(typeof(T) == typeof(IWeaponItem));
            _foodsContentHolder.gameObject.SetActive(typeof(T) == typeof(IFoodItem));
            _usableItemsContentHolder.gameObject.SetActive(typeof(T) == typeof(IUsableItem));
        }

        public Transform GetContentHolder<T>() where T : IInventoryItem
        {
            if (typeof(T) == typeof(IWeaponItem)) return _weaponsContentHolder;
            else if (typeof(T) == typeof(IFoodItem)) return _foodsContentHolder;
            else return _usableItemsContentHolder;
        }

        public void Hide()
        {
            _weaponsContentHolder.gameObject.SetActive(false);
            _foodsContentHolder.gameObject.SetActive(false);
            _usableItemsContentHolder.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke();
        }
    }
}