using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Move mode button.")]
    private Button m_MoveButton;

    [SerializeField]
    [Tooltip("Inspect mode button.")]
    private Button m_InspectButton;

    [SerializeField]
    [Tooltip("Interact mode button.")]
    private Button m_InteractButton;

    [SerializeField]
    [Tooltip("Inventory button.")]
    private Button m_InventoryButton;

    [SerializeField]
    [Tooltip("The color to highlight the active mode's button.")]
    private Color m_ModeSelectColor;

    // [SerializeField]
    // [Tooltip("The scale of the active mode's button.")]
    // private float m_ModeSelectScale;
    #endregion

    #region Private Variables
    /** A mode indicator. The numbers mean:
     *  0: Move
     *  1: Inspect
     *  2: Interact/Talk
     *  3: Inventory
     */
    private int p_ModeInt;

    private Button[] p_ButtonList;
    #endregion

    #region Initialization
    private void Awake() {
        p_ModeInt = 0;
        p_ButtonList = new Button[4]{m_MoveButton, m_InspectButton, m_InteractButton, m_InventoryButton};
        ModeColor();
    }
    #endregion

    #region Update Methods
    private void Update() {
        ModeSelect();
    }
    #endregion

    #region Mode Methods
    private void ModeSelect() {
        if (Input.GetKeyDown("1")) {
            Debug.Log("Mode: Move");
            p_ModeInt = 0;
        } else if (Input.GetKeyDown("2")) {
            Debug.Log("Mode: Inspect");
            p_ModeInt = 1;
        } else if (Input.GetKeyDown("3")) {
            Debug.Log("Mode: Interact");
            p_ModeInt = 2;
        } else if (Input.GetKeyDown("4")) {
            Debug.Log("Mode: Inventory");
            p_ModeInt = 3;
        } else {
            return;
        }
        ModeColor();
    }

    private void ModeColor() {
        for (int i = 0; i < 4; i++) {
            if (i == p_ModeInt) {
                p_ButtonList[i].GetComponent<Image>().color = m_ModeSelectColor;
            } else {
                p_ButtonList[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
    #endregion

    #region Player Methods
    public bool IsMoveMode() {
        if (p_ModeInt == 0) {
            return true;
        } else {
            return false;
        }
    }
    #endregion
}
