using TMPro;
using UnityEngine;

namespace Inventory.InventoryVisualizer
{
	public class InfoWindowWithStats : DefaultInfoWindow
	{
		[field: SerializeField] public TMP_Text StatsText { get; protected set; }
	}
}