using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PopulateInventory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Tooltip("these are the item prefabs")]
    private GameObject[] items;
    [SerializeField]
    [Tooltip("this is the transform for the grid")]
    private Transform grid;


    void Awake()
    {
        Dictionary<string, int> itemList = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>().get_Inventory();
        foreach(string key in itemList.Keys) {
            foreach (GameObject o in items) {
                
                if (key == o.name) {
                    Instantiate(o, grid, false); //instantiate
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
