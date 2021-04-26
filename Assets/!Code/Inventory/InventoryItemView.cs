using UnityEngine;
using UnityEngine.UI;


namespace Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Image _image;
        
        public Toggle Toggle => _toggle;
        public Image Image => _image;
    }
}