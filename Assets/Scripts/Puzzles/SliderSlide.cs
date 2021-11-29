using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSlide : MonoBehaviour
{
    public Vector3 targetPos;
    private Vector3 correctPos;
    public int number;

    private bool isCorrect;
    public bool IsCorrect {
        get {
            return isCorrect;
        }
    }

    void Awake()
    {
        targetPos = transform.position;
        correctPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
        if (targetPos == correctPos) {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 1, 0.4f, 1);
            isCorrect = true;
        } else {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            isCorrect = false;
        }
    }
}
