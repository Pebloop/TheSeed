/*
 * An Iventory cell of the inventory menu
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

using Microsoft.MixedReality.Toolkit.UI;
using TheSeed.Database;
using TMPro;
using UnityEngine;

namespace TheSeed.Menus.Inventory
{
    /// <summary>
    /// An Iventory cell of the inventory menu
    /// </summary>
    public class InventoryCell : MonoBehaviour
    {
        /// <summary>
        /// The item reference of the cell.
        /// </summary>
        public Item itemReference = null;
        
        public Interactable interactable;
        public ButtonConfigHelper buttonConfigHelper;
        public TextMeshPro text;

        // Start is called before the first frame update
        void Start()
        {
            updateIcon();
        }

        // Update is called once per frame
        void Update()
        {
            updateIcon();
        }

        void updateIcon()
        {
            if (itemReference == null)
            {
                buttonConfigHelper.SetSpriteIconByName("None");
                text.text = "";
            } else
            {
                buttonConfigHelper.SetSpriteIcon(itemReference.Icon);
                text.text = itemReference.Name;
            }
        }
    }
}
