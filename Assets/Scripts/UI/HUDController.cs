using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("manager so that we can destroy all the spawned items when switching modes")]
    private GameObject m_ButtonManager;
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
    [Tooltip("Normal move icon.")]
    private Sprite m_MoveIcon;

    [SerializeField]
    [Tooltip("HUD parent object Transform")]
    private Transform m_Parent;

    [SerializeField]
    [Tooltip("Normal inspect icon.")]
    private Sprite m_InspectIcon;

    [SerializeField]
    [Tooltip("Normal interact icon.")]
    private Sprite m_InteractIcon;

    [SerializeField]
    [Tooltip("Normal inventory icon.")]
    private Sprite m_InventoryIcon;

    [SerializeField]
    [Tooltip("Highlighted move icon.")]
    private Sprite m_MoveHighlight;

    [SerializeField]
    [Tooltip("Highlighted inspect icon.")]
    private Sprite m_InspectHighlight;

    [SerializeField]
    [Tooltip("Highlighted interact icon.")]
    private Sprite m_InteractHighlight;

    [SerializeField]
    [Tooltip("Highlighted inventory icon.")]
    private Sprite m_InventoryHighlight;


    // [SerializeField]
    // [Tooltip("Move mode cursor.")]
    // private Texture2D m_MoveCursor;

    // [SerializeField]
    // [Tooltip("Inspect mode cursor.")]
    // private Texture2D m_InspectCursor;

    // [SerializeField]
    // [Tooltip("Interact mode cursor.")]
    // private Texture2D m_InteractCursor;

    // [SerializeField]
    // [Tooltip("Default cursor.")]
    // private Texture2D m_DefaultCursor;

    [SerializeField]
    [Tooltip("The color to highlight the active mode's button.")]
    private Color m_ModeSelectColor;

    // [SerializeField]
    // [Tooltip("The scale of the active mode's button.")]
    // private float m_ModeSelectScale;

    [SerializeField]
    [Tooltip("Whether or not the mode can be changed. Useful for puzzles.")]
    private bool m_CanChange;

    [SerializeField]
    [Tooltip("The default mode int in case of puzzles. Defaults to 0.")]
    private int m_DefaultMode;

    #endregion

    #region Private Variables
    /** A mode indicator. The numbers mean:
     *  0: Move
     *  1: Inspect
     *  2: Interact/Talk
     *  3: Inventory
     */
    private int p_ModeInt;
    public int ModeInt {
        get {
            return p_ModeInt;
        }
    }

    private Button[] p_ButtonList;

    private GameObject[] buttons;
    #endregion

    #region Cached Components
    private Image cc_MoveImage;
    private Image cc_InspectImage;
    private Image cc_InteractImage;
    private Image cc_InventoryImage;
    #endregion

    #region Initialization
    private void Awake() {
        if (m_DefaultMode == default(int)) {
            m_DefaultMode = 0;
        }
        p_ModeInt = m_DefaultMode;
        p_ButtonList = new Button[4]{m_MoveButton, m_InspectButton, m_InteractButton, m_InventoryButton};

        buttons = GameObject.FindGameObjectsWithTag("Button");

        cc_MoveImage = m_MoveButton.GetComponent<Image>();
        cc_InspectImage = m_InspectButton.GetComponent<Image>();
        cc_InteractImage = m_InteractButton.GetComponent<Image>();
        cc_InventoryImage = m_InventoryButton.GetComponent<Image>();

        ModeButtonChange();
    }
    #endregion

    #region Update Methods
    private void Update() {
        if (m_CanChange) {
            ModeSelect();
        }
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
        ModeButtonChange();
    }

    public void SetMode(int i) {
        if (i >= 0 && i <= 3) {
            Debug.Log("mode changed to " + i);
            p_ModeInt = i;
        }
        ModeButtonChange();
    }

   
    private void ModeButtonChange() {
        cc_MoveImage.sprite = m_MoveIcon;
        cc_InspectImage.sprite = m_InspectIcon;
        cc_InteractImage.sprite = m_InteractIcon;
        cc_InventoryImage.sprite = m_InventoryIcon;
        
        switch (p_ModeInt) {
            case 0:
                cc_MoveImage.sprite = m_MoveHighlight;

                break;
            case 1:
                cc_InspectImage.sprite = m_InspectHighlight;

                break;
            case 2:
                cc_InteractImage.sprite = m_InteractHighlight;

                break;
            case 3:

                break;
            default:
                p_ModeInt = 0;
                break;            
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

    public int GetMode() {
        return p_ModeInt;
    }

    public void disableButtons() {
        foreach(var b in buttons) {
            b.SetActive(false);
        }
    }

    public void enableButtons() {
        foreach (var b in buttons) {
            b.SetActive(true);
        }
    }
    #endregion
}
