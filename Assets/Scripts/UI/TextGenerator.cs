using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour
{
    [SerializeField]
    private Text text;
    public string toWrite;

    public float time;
    private float elapsed;

    private void Start() {
        if(time == 0f) {
            time = 3;
            elapsed = 0;
        }
    }
    private void Update() {
        if(elapsed < time) {
            elapsed += Time.deltaTime;
            int charNum = (int)(elapsed / time * toWrite.Length);
            text.text = toWrite.Substring(0, charNum);

            Debug.Log(toWrite.Substring(0, charNum));
        } else {
            text.text = toWrite;
        }
    }
}
