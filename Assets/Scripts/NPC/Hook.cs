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
    private bool hit;
    private float timer;
    private Vector3 startPos;


    private void Start() {
        p_XScale = transform.localScale.x;
        p_YScale = transform.localScale.y;
        inProgrss = false;
        hit = false;
        timer = 0;
        startPos = new Vector3(0, 5, 0);
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
        float scale = 1f - (Scale * (transform.position.y - 5.0f));
        transform.localScale = new Vector3(scale * p_XScale, scale * p_YScale, 1);
    }

    private IEnumerator moveHorizontal(Vector3 position) {

        Vector3 me = this.gameObject.transform.position;
        Vector3 target1 = this.gameObject.transform.position;
        target1.x = position.x;
        
        float elapsed = 0;
        while (this.gameObject.transform.position != target1) {
            var curr = Vector3.Lerp(me, target1, elapsed/3);
            this.gameObject.transform.position = curr;
            elapsed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("moving horizontally");
        yield return StartCoroutine(moveVertical(position));
    }

    private IEnumerator moveVertical(Vector3 position) {
        Debug.Log("moving vertically");

        Vector3 me = this.gameObject.transform.position;
        Vector3 target2 = this.gameObject.transform.position;
        target2.y = ((position.y + 3)/4) + 4.5f;

        float elapsed = 0;
        while (this.gameObject.transform.position != target2) {
            var curr = Vector3.Lerp(me, target2, elapsed);
            this.gameObject.transform.position = curr;
            elapsed += Time.deltaTime;
            ScaleY();
            yield return null;
        }

        yield return StartCoroutine(drop());
    }

    private IEnumerator drop() {
        Debug.Log("dropping");

        Vector3 me = this.gameObject.transform.position;
        Vector3 target2 = me;
        target2.y -= 7.25f;

        float elapsed = 0;
        while (this.gameObject.transform.position.y != target2.y) {
            var curr = Vector3.Lerp(me, target2, elapsed);
            

            if (player.transform.position.y > target2.y) {
                Vector3 tmp = player.transform.position;
                curr.z = -5;
            } else {
                Vector3 tmp = player.transform.position;
                curr.z = 5;
            }
            this.gameObject.transform.position = curr;
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (hit) {
            player.takeDamage();
            Debug.Log("Hit Player");
        }

        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(reset());
    }

    private IEnumerator reset() {
        Debug.Log("resetting");

        Vector3 me = this.gameObject.transform.position;

        float elapsed = 0;
        while (this.gameObject.transform.position != startPos) {
            var curr = Vector3.Lerp(me, startPos, elapsed);
            this.gameObject.transform.position = curr;
            elapsed += Time.deltaTime;
            yield return null;
        }

        hit = false;
        timer = 0;
        inProgrss = false;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name.Equals("Player")) {
            hit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name.Equals("Player")) {
            hit = false;
        }
    }

}
