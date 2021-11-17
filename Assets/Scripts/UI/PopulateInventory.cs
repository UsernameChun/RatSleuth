using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PopulateInventory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Tooltip("these are the item prefabs")]
    private GameObject itemHolder;
    [SerializeField]
    [Tooltip("this is the transform for the grid")]
    private Transform grid;
    

    void Awake()
    {
        Dictionary<string, int> itemList = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>().get_Inventory();
        for (int i = 0; i < 10; i ++ ) {
            Instantiate(itemHolder, grid, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
