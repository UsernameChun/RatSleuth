using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The conversation to be had on interaction.")]
    private Convo[] m_Conversation;

    [SerializeField]
    [Tooltip("The object to display the conversation in.")]
    private GameObject m_DiaBox;

    [SerializeField]
    [Tooltip("A HUD Controller object to check modes.")]
    private GameObject m_HUD;

    public GameObject parent;
    public AudioSource source;
    public Animator animator;
    public ChainBuilder chain;
    public Checkpoint ckpt;
    public bool talkable;
    public bool showChildren;
    public GameObject[] force;

    private List<GameObject> disabled;
    [SerializeField]
    [Tooltip("Whether or not the item is something that can be picked up.")]
    private bool m_IsItem;
    #endregion

    #region Cached Components  
    private Image p_Portrait;
    private Text p_Name;
    private Text p_Text;


    private HUDController p_HUDController;
    #endregion

    #region Private Variables
    private int p_Index;
    private int mode;
    private string p_ObjectName;
    Vector3 ls = new Vector3(0f, 0f, 0f);
    GameObject[] x = null;
    #endregion

    #region Initialization
    private void init() {
        p_Portrait = m_DiaBox.transform.GetChild(0).gameObject.GetComponent<Image>();
        p_Name = m_DiaBox.transform.GetChild(1).gameObject.GetComponent<Text>();
        p_Text = m_DiaBox.transform.GetChild(2).gameObject.GetComponent<Text>();

        p_Index = -1;

        p_HUDController = m_HUD.GetComponent<HUDController>();


        if (talkable) {
            mode = 2;
        }
        else {
            mode = 1;
        }
        ls = this.GetComponent<Collider2D>().transform.localScale;
        disabled = new List<GameObject>();
    }

    private void Awake() {
        init();
        parent = this.transform.parent.gameObject;
    }
    #endregion

    #region Update Methods
    private void OnMouseDown() {

        if (!IsTalking() && p_HUDController.ModeInt == mode) {
            init();
            this.GetComponent<Collider2D>().transform.localScale = new Vector3(5000f, 5000f, 0);
            foreach (var c in parent.GetComponentsInChildren<Collider2D>()) {
                if (c.name != this.gameObject.name) {
                    c.gameObject.SetActive(false);
                    disabled.Add(c.gameObject);
                }
            }
            ChangeState(true);
            Debug.Log("Disabling buttons" + this.gameObject.name);
            m_HUD.GetComponent<HUDController>().disableButtons();
        }

        if (p_HUDController.ModeInt == mode) {
            p_Index++;
        }
        if (p_Index >= 0 && p_Index < m_Conversation.Length && p_HUDController.ModeInt == mode)
        {
            p_Portrait.sprite = Liner(p_Index).portrait;
            p_Name.text = Liner(p_Index).name;
            p_Name.color = new Color(0, 0, 0, 1);
            p_Text.text = Liner(p_Index).text;
            p_Text.color = new Color(0, 0, 0, 1);

            if (source != null) {
                source.Stop();
                source.PlayOneShot(Liner(p_Index).audio);
            }
        }
        else if (p_Index >= this.m_Conversation.Length)
        {
            m_HUD.GetComponent<HUDController>().enableButtons();

            this.GetComponent<Collider2D>().transform.localScale = ls;
            m_DiaBox.SetActive(false);
            p_Index = -1;
            animator.SetBool("isTalking", false);
            Debug.Log("Reactivating button s" + this.gameObject.name);
            foreach (var c in disabled) {
                c.SetActive(true);
            }
            if (p_ObjectName == this.gameObject.name && m_IsItem) {
                gameObject.SetActive(false);
            }
            if (ckpt != null) {
                ckpt.passCheckpoint();
            }
            if (chain != null) {
                chain.Phase();
            }
            if (showChildren)
            {
                force[0].GetComponent<NPCController>().forceProgression();
                force[0].GetComponent<NPCController>().shrinkMe();
            }
            PuzzleShower puzzle = this.GetComponent<PuzzleShower>();
            if (puzzle != null) {
                puzzle.ShowPuzzle();
            }
        }
        else if (p_HUDController.ModeInt != mode)
        {
            m_DiaBox.SetActive(false);
            p_Index = -1;

        }
        if (IsTalking() == false) {
            p_Index = -1;
        }
        else if (mode == 2) {
            animator.SetBool("isTalking", true);
        }
    }
    #endregion

    #region Dialogue Methods
    private Convo Liner(int i) {
        return m_Conversation[i];
    }

    public void skipMe() {
        if(chain != null) {
            chain.Phase();
        }
        else {
            Debug.Log("Nothing to skip to");
        }
    }

    public void shrinkMe() {
        this.GetComponent<Collider2D>().transform.localScale = ls;


    }

    public void forceProgression() {
          
        init();
        this.GetComponent<Collider2D>().transform.localScale = new Vector3(5000f, 5000f, 0);
        ChangeState(true);
        m_HUD.GetComponent<HUDController>().disableButtons();
        p_Index++;
        p_Portrait.sprite = Liner(p_Index).portrait;
        p_Name.text = Liner(p_Index).name;
        p_Name.color = new Color(0, 0, 0, 1);
        p_Text.text = Liner(p_Index).text;
        p_Text.color = new Color(0, 0, 0, 1);
        if (mode == 2) {
            animator.SetBool("isTalking", true);
        }
    }
    #endregion

    #region Check Methods
    public bool IsTalking() {
        return m_DiaBox.activeInHierarchy;
    }

    public void ChangeState(bool b) {
        m_DiaBox.SetActive(b);
        p_ObjectName = this.gameObject.name;
        if (m_IsItem) {
            Inventory.inv.add_to_inventory("inv_Key");
        }

    }
    #endregion

    [System.Serializable]
    private class Convo {
        [SerializeField]
        public Sprite portrait;

        [SerializeField]
        public string name;

        [SerializeField]
        public string text;

        [SerializeField]
        public AudioClip audio;
    }
}
