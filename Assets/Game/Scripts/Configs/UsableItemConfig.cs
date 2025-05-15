using UnityEngine;
using Gameplay.Inventory;

namespace Assets.Game.Scripts.Configs
{
    [CreateAssetMenu()]
    public class UsableItemConfig : ScriptableObject, IUsableItem
    {
        [field: SerializeField] public string Name{ get; private set; }
        [field: SerializeField] public string Description{ get; private set; }
        [field: SerializeField] public Sprite Icon{ get; private set; }

        public void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}