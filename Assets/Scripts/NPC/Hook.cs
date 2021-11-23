using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public PlayerController player;
    public float Scale;
    public float Frequency;

    private float p_XScale;
    private float p_YScale;
    private bool inProgrss;
    private float timer;


    private void Start() {
        p_XScale = transform.localScale.x;
        p_YScale = transform.localScale.y;
        inProgrss = false;
        timer = 0;
    }

    private void Update() {
        if (!inProgrss) {
            timer += Time.deltaTime;
        }
        if (timer > Frequency) {
            timer = 0;
            inProgrss = true;
            StartCoroutine(moveHorizontal(player.transform.position));

        }
    }

    private void ScaleY() {
        float scale = 1.0f - (Scale * (transform.position.y + 2.0f));
        transform.localScale = new Vector3(scale * p_XScale, scale * p_YScale, 1);
    }

    private IEnumerator moveHorizontal(Vector3 position) {
        Debug.Log("moving horizontally");

        Vector3 me = this.gameObject.transform.position;
        Vector3 target1 = this.gameObject.transform.position;
        target1.x = position.x;
        
        float elapsed = 0;
        while (this.gameObject.transform.position != position) {
            var curr = Vector3.Lerp(me, target1, elapsed);
            this.gameObject.transform.position = curr;
            elapsed += Time.deltaTime;
        }
        yield return StartCoroutine(moveVertical(position));
    }

    private IEnumerator moveVertical(Vector3 position) {
        Debug.Log("moving vertically");

        Vector3 me = this.gameObject.transform.position;
        Vector3 target2 = this.gameObject.transform.position;
        target2.y = position.y + 5;

        float elapsed = 0;
        while (this.gameObject.transform.position != position) {
            var curr = Vector3.Lerp(me, target2, elapsed);
            this.gameObject.transform.position = curr;
            elapsed += Time.deltaTime;
            ScaleY();
            yield return null;
        }
        
    }


}
