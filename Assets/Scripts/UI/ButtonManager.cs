using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [SerializeField]
    [Tooltip("the associated item to spawn in when clicked")]
    GameObject SpawnItem;

    private GameObject spawnedItem;

    // Start is called before the first frame update
    public void on_Item_press() {
        Debug.Log("item pressed");
        GameObject inv_Panel = gameObject.transform.parent.gameObject; //get the parent
        Debug.Log("spawning item");
        inv_Panel.GetComponent<PopulateInventory>().selectedItem = Instantiate(SpawnItem, inv_Panel.transform.parent, false);
        inv_Panel.SetActive(false); //disable the item press
    }

}
