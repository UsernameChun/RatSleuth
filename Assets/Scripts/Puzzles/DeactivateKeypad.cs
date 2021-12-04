using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateKeypad : MonoBehaviour
{
    public void DeactivateIt() {
        KeypadPuzzle.p_InputtedCode = "";
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
