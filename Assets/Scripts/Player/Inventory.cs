using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    private class InventorySerialObject {
        public Dictionary<string, int> itemList;
    }
    public static void add_to_inventory(string item, int amount) {
        BinaryFormatter bf = new BinaryFormatter();
        InventorySerialObject deserial = null;
        Dictionary<string, int> items = null;
        FileStream fp = new FileStream(Application.dataPath + "/inventory", FileMode.OpenOrCreate);
        if (File.Exists(Application.dataPath + "/inventory") && fp.Length > 0) {
            deserial = (InventorySerialObject) bf.Deserialize(fp);
            items = deserial.itemList;
        } else {
            items = new Dictionary<string, int>();
        }
        if (!items.ContainsKey(item)) {
            items.Add(item, amount);
        } else {
            items[item] += amount;
        }
        bf.Serialize(fp, items);
        fp.Close();
    }

    /* removes "amount" items with name "item" from the inventory, assumes that player  */
    public static void remove_from_inventory(string item, int amount) {
        FileStream fp = new FileStream(Application.dataPath + "/inventory.json", FileMode.OpenOrCreate);
        BinaryFormatter bf = new BinaryFormatter();
        if (fp.Length <= 0) { //empty inventory
            fp.Close();
            return;
        } else {
            InventorySerialObject deserial = (InventorySerialObject) bf.Deserialize(fp);
            Dictionary<string, int> items = deserial.itemList;
            if (items.ContainsKey(item) && items[item] > amount) {
                items[item] -= amount;
            } 
            bf.Serialize(fp, items);
        }
        fp.Close();
    }


}
