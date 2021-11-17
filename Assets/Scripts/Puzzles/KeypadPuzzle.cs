using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadPuzzle : MonoBehaviour
{
    private static string m_CorrectCode = "364";

    [SerializeField]
    [Tooltip("The checkpoint associated with this puzzle.")]
    private Checkpoint m_Checkpoint;

    public static string p_InputtedCode ="";
    private static int p_DigitCount = 0;

    void Update()
    {
        Debug.Log(p_InputtedCode);

        if (p_DigitCount == 3) {
            if (p_InputtedCode.Equals(m_CorrectCode)) {
                m_Checkpoint.passCheckpoint();
                Debug.Log("Password correct.");
            } else {
                p_InputtedCode = "";
                p_DigitCount = 0;
            }
        }
    }

    void OnMouseDown() {
        p_InputtedCode += gameObject.name;
        p_DigitCount += 1;
    }
}
