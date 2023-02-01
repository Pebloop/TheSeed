using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    public GameManager gameManager;
    public List<GameObject> itemButtons;
    public GameObject itemButtonPrefab;
    public GameObject itemButtonContainer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameManager.GetMyInfo().inventorySize; i++)
        {
            itemButtons.Add(Instantiate(itemButtonPrefab, itemButtonContainer.transform));
        }
        itemButtonContainer.GetComponent<GridObjectCollection>().UpdateCollection();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
