using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.InventoryVisualizer
{
    public class DefaultInfoWindow : MonoBehaviour
    {
        [field: SerializeField] public TMP_Text NameText { get; protected set; }
        [field: SerializeField] public TMP_Text DescriptionText { get; protected set; }
        [field: SerializeField] public Image Icon { get; protected set; }
    }
}
