using UnityEngine;
using UnityEngine.UI;


namespace Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;

        public Button Button => _button;
        public Image Image => _image;
    }
}