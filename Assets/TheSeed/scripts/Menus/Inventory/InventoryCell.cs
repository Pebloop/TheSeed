using Microsoft.MixedReality.Toolkit.UI;
using TheSeed.Database;
using TMPro;
using UnityEngine;

public class InventoryCell : MonoBehaviour
{
    Item itemReference = null;
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
            buttonConfigHelper.SetSpriteIcon(itemReference.ItemIcon);
            text.text = itemReference.ItemName;
        }
    }
}
