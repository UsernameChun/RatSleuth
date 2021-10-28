using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inspectable : MonoBehaviour
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
    public int[] breakpoints;
    #endregion

    #region Cached Components  
    private Image p_Portrait;
    private Text p_Name;
    private Text p_Text;

    private HUDController p_HUDController;
    #endregion

    #region Private Variables
    private int p_Index;
    private int currBase;
    private int currLmt;
    #endregion

    #region Initialization
    private void Awake() {
        p_Portrait = m_DiaBox.transform.GetChild(0).gameObject.GetComponent<Image>();
        p_Name = m_DiaBox.transform.GetChild(1).gameObject.GetComponent<Text>();
        p_Text = m_DiaBox.transform.GetChild(2).gameObject.GetComponent<Text>();

        p_Index = -1;

        p_HUDController = m_HUD.GetComponent<HUDController>();
        currLmt = 0;
        currBase = 0;
    }
    #endregion

    #region Update Methods
    private void Update() {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))) {
            p_Index++;
        }
        Debug.Log(p_Index + " " + currLmt);

        if (IsTalking() && p_HUDController.ModeInt == 2) {
            if (p_Index <= breakpoints[currLmt]) {
                p_Portrait.sprite = Liner(p_Index).portrait;
                p_Name.text = Liner(p_Index).name;
                p_Name.color = new Color(1, 1, 1, 1);
                p_Text.text = Liner(p_Index).text;
                p_Text.color = new Color(1, 1, 1, 1);
            }
            else {
                m_DiaBox.SetActive(false);
                if(currLmt < this.breakpoints.Length) {
                    currLmt++;
                }
            }
        }

        if (IsTalking() == false) {
            animator.SetBool("isTalking", false);
        }
        else {
            animator.SetBool("isTalking", true);
        }
    }
    #endregion

    #region Dialogue Methods
    private Convo Liner(int i) {
        return m_Conversation[i];
    }
    #endregion

    #region Check Methods
    public bool IsTalking() {
        return m_DiaBox.activeInHierarchy;
    }

    public void ChangeState() {
        m_DiaBox.SetActive(true);
    }
    #endregion

    [System.Serializable]
    private class Convo
    {
        [SerializeField]
        public Sprite portrait;

        [SerializeField]
        public string name;

        [SerializeField]
        public string text;
    }
}
