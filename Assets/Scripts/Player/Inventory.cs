using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    private class InventorySerialObject {
        public Dictionary<string, int> itemList;
    }
    public static void add_to_inventory(string item, int amount) {
        InventorySerialObject deserial = JsonUtility.FromJson<InventorySerialObject>(Application.dataPath + Path.PathSeparator + "inventory.json");
        Dictionary<string, int> items = deserial.itemList;
        if (!items.ContainsKey(item)) {
            items.Add(item, amount);
        } else {
            items[item] += amount;
        }
        string data = JsonUtility.ToJson(deserial);
        using(StreamWriter writer = new StreamWriter(Application.dataPath + Path.PathSeparator + "inventory.json")) {
            writer.Write(data);
        }
    }

    /* removes "amount" items with name "item" from the inventory, assumes that player  */
    public static void remove_from_inventory(string item, int amount) {
        InventorySerialObject deserial = JsonUtility.FromJson<InventorySerialObject>(Application.dataPath + Path.PathSeparator + "inventory.json");
        Dictionary<string, int> items = deserial.itemList;
        if (items.ContainsKey(item) && items[item] > amount) {
            items[item] -= amount;
        } 
        string data = JsonUtility.ToJson(deserial);
        using(StreamWriter writer = new StreamWriter(Application.dataPath + Path.PathSeparator + "inventory.json")) {
            writer.Write(data);
        }
    }


}
