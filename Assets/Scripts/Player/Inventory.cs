using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    private class InventorySerialObject {
        public List<(string, int)> itemList;
    }
    public static void add_to_inventory(string item) {
        InventorySerialObject deserial = JsonUtility.FromJson<InventorySerialObject>(Application.dataPath + Path.PathSeparator + "inventory.json");
        List<(string, int)> items = deserial.itemList;
        if (items.Count == 0) {
            items.Add((item, 1));
        }
        foreach ((string i, int j) in items) {
            if (item == i) {
                int store = j + 1;
                items.Remove((i, j));
                items.Add((i, store));
                break;
            }
        }
        string data = JsonUtility.ToJson(deserial);
        using(StreamWriter writer = new StreamWriter(Application.dataPath + Path.PathSeparator + "inventory.json")) {
            writer.Write(data);
        }
    }


}
