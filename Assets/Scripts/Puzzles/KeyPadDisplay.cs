using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadDisplay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = KeypadPuzzle.p_InputtedCode;
    }
}
