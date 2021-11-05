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

    public Animator animator;
    public ChainBuilder chain;
    public Checkpoint ckpt;
    public bool talkable;
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
    }

    private void Awake() {
        init();
    }
    #endregion

    #region Update Methods


    private void OnMouseDown() {
        if (!IsTalking() && p_HUDController.ModeInt == mode) {
            init();
            ChangeState(true);
        }

        if (p_HUDController.ModeInt == mode) {
            p_Index++;
        }
        if (p_Index >= 0 && p_Index < m_Conversation.Length && p_HUDController.ModeInt == mode) {
            p_Portrait.sprite = Liner(p_Index).portrait;
            p_Name.text = Liner(p_Index).name;
            p_Name.color = new Color(1, 1, 1, 1);
            p_Text.text = Liner(p_Index).text;
            p_Text.color = new Color(1, 1, 1, 1);
        }
        else if (p_Index >= this.m_Conversation.Length) {
            if (chain != null) {
                chain.Phase();
            }
            if (ckpt != null) {
                ckpt.passCheckpoint();
            }

            m_DiaBox.SetActive(false);
            p_Index = -1;
        }
        else if (p_HUDController.ModeInt != mode) {
            m_DiaBox.SetActive(false);
            p_Index = -1;
        }

        if (IsTalking() == false) {
            p_Index = -1;
            animator.SetBool("isTalking", false);
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
    #endregion

    #region Check Methods
    public bool IsTalking() {
        return m_DiaBox.activeInHierarchy;
    }

    public void ChangeState(bool b) {
        m_DiaBox.SetActive(b);
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
    }
}
