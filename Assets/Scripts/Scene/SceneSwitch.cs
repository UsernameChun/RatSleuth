using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The name of the scene to switch to.")]
    private string name;

    [SerializeField]
    [Tooltip("the item to consume")]
    private string item;

    [SerializeField]
    [Tooltip("The inventory panel")]
    private GameObject inv_Panel;
    #endregion

    #region Scene Methods
    public void Switch() {
        Inventory.inv.remove_from_inventory(item); //update db
        inv_Panel.GetComponent<PopulateInventory>().populate(); //reorganize the inventory
        SceneManager.LoadScene(name);
    }
    #endregion
}
