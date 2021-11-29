using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PopulateInventory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Tooltip("these are the item prefabs")]
    List<GameObject> itemHolder;
    [SerializeField]
    [Tooltip("this is the transform for the grid")]
    private Transform grid;
    

    public void populate() {
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }

        List<string> itemList = Inventory.inv.get_Inventory();
        foreach (string key in itemList) {
            foreach (GameObject i in itemHolder) {
                if (i.name == key) {
                    Instantiate(i, grid, false); //relative to real parent
                }
            }
        }
    }

}
