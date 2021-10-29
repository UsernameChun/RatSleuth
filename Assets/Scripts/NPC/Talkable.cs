using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Talkable : MonoBehaviour
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
    public int[] checkpoints;
    public PlotController plt;
    #endregion

    #region Cached Components  
    private Image p_Portrait;
    private Text p_Name;
    private Text p_Text;

    private HUDController p_HUDController;
    #endregion

    #region Private Variables
    private int p_Index;
    private int loopBase;
    private int currLmt;
    private int reset;
    private bool needToTurnOff = false;
    #endregion

    #region Initialization
    private void Awake() {
        p_Portrait = m_DiaBox.transform.GetChild(0).gameObject.GetComponent<Image>();
        p_Name = m_DiaBox.transform.GetChild(1).gameObject.GetComponent<Text>();
        p_Text = m_DiaBox.transform.GetChild(2).gameObject.GetComponent<Text>();

        p_Index = 0;

        p_HUDController = m_HUD.GetComponent<HUDController>();
        currLmt = 0;
        loopBase = breakpoints[breakpoints.Length - 1] + 1;
        reset = 0;
    }
    #endregion

    #region Update Methods
    private void Update() {
        if ((Input.GetMouseButtonDown(0) && IsTalking())) {
            needToTurnOff = true;
            p_Index++;
        }

        if (IsTalking() && p_HUDController.ModeInt == 2) {
            if (currLmt < breakpoints.Length) {
                if (p_Index <= breakpoints[currLmt]) {
                    p_Portrait.sprite = Liner(p_Index).portrait;
                    p_Name.text = Liner(p_Index).name;
                    p_Name.color = new Color(1, 1, 1, 1);
                    p_Text.text = Liner(p_Index).text;
                    p_Text.color = new Color(1, 1, 1, 1);

                    for (int i = 0; i < checkpoints.Length; i++) {
                        if (checkpoints[i] == p_Index) {
                            plt.passCheckpoint(i);
                            Debug.Log("Checkpoint passed");
                        }
                    }
                }
                else {
                    reset = p_Index - 1;
                    m_DiaBox.SetActive(false);
                    currLmt++;
                }
            }
            else {
                //begin end looping
                if (p_Index >= 0 && p_Index < m_Conversation.Length && p_HUDController.ModeInt == 2) {
                    p_Portrait.sprite = Liner(p_Index).portrait;
                    p_Name.text = Liner(p_Index).name;
                    p_Name.color = new Color(1, 1, 1, 1);
                    p_Text.text = Liner(p_Index).text;
                    p_Text.color = new Color(1, 1, 1, 1);
                }
                else {
                    m_DiaBox.SetActive(false);
                    p_Index = loopBase;
                }
            }
        }
        if (p_Index >= m_Conversation.Length) {
            p_Index = loopBase;
        }

        if (IsTalking() == false) {
            animator.SetBool("isTalking", false);
        }
        else {
            animator.SetBool("isTalking", true);
        }
    }

    public void restartConvo() {
        p_Index = reset;
        if (needToTurnOff) {
            m_DiaBox.SetActive(false);
            needToTurnOff = false;
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
