using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class Inventory : MonoBehaviour
{
    //Singleton to persist between scene switches
    public static Inventory inv {
        get;
        set;
    }

    private List<string> itemsToExclude;
    // [System.Serializable]
    // private class InventorySerialObject {
    //     public Dictionary<string, int> itemList;
    // }

    private List<string> itemList;

    void Awake() {
        if (inv != null) {
            Destroy(gameObject);
        } else {
            inv = this;
            DontDestroyOnLoad(gameObject);
        }
        itemsToExclude = new List<string>();
        itemList = new List<string>();
    }
    public void add_to_inventory(string item) {
        // BinaryFormatter bf = new BinaryFormatter();
        // InventorySerialObject deserial = null;
        // Dictionary<string, int> items = null;
        // FileStream fp = new FileStream(Application.dataPath + "/inventory", FileMode.OpenOrCreate);
        // if (File.Exists(Application.dataPath + "/inventory") && fp.Length > 0) {
        //     deserial = (InventorySerialObject) bf.Deserialize(fp);
        //     items = deserial.itemList;
        // } else {
        //     items = new Dictionary<string, int>();
        // }
        // if (!item.Equals("Map")) {
        //     if (!items.ContainsKey(item)) {
        //         items.Add(item, amount);
        //     } else {
        //         items[item] += amount;
        //     }
        // }
        // bf.Serialize(fp, items);
        // fp.Close();

        if (!itemList.Contains(item) && !itemsToExclude.Contains(item)) {
            itemList.Add(item);
        } else {
            return;
        }
    }

    /* removes "amount" items with name "item" from the inventory, assumes that player  */
    public void remove_from_inventory(string item) {
        // FileStream fp = new FileStream(Application.dataPath + "/inventory.json", FileMode.OpenOrCreate);
        // BinaryFormatter bf = new BinaryFormatter();
        // if (fp.Length <= 0) { //empty inventory
        //     fp.Close();
        //     return;
        // } else {
        //     InventorySerialObject deserial = (InventorySerialObject) bf.Deserialize(fp);
        //     Dictionary<string, int> items = deserial.itemList;
        //     if (items.ContainsKey(item) && items[item] > amount) {
        //         items[item] -= amount;
        //     } 
        //     bf.Serialize(fp, items);
        // }
        // fp.Close();
        if (itemList.Contains(item)) {
            itemList.Remove(item);
        } else {
            return;
        }
    }

    public  List<string> get_Inventory() {
        // BinaryFormatter bf = new BinaryFormatter();
        // InventorySerialObject deserial = null;
        // Dictionary<string, int> items = null;
        // FileStream fp = new FileStream(Application.dataPath + "/inventory", FileMode.OpenOrCreate);
        // if (File.Exists(Application.dataPath + "/inventory") && fp.Length > 0) {
        //     deserial = (InventorySerialObject) bf.Deserialize(fp);
        //     items = deserial.itemList;
        // } else {
        //     items = new Dictionary<string, int>();
        // }
        // fp.Close();
        // return items;
        return itemList;

    }


}
