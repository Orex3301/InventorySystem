using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Inventory
{
	public abstract class ItemCell : MonoBehaviour
	{
		[SerializeField] protected Image _icon;
	}
}