using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The speed at which the player moves.")]
    private float m_MoveSpeed;

    [SerializeField]
    [Tooltip("The HUD Controller.")]
    private GameObject m_HUD;

    [SerializeField]
    [Tooltip("Have we hit a wall")]
    private bool wall = false;

    private Coroutine moveCoroutine = null;
    #endregion

    #region Cached References
    private float p_XScale;
    private float p_YScale;
    #endregion

    #region Initialization
    private void Awake() {
        p_XScale = transform.localScale.x;
        p_YScale = transform.localScale.y;
    }
    #endregion

    #region Update Methods
    private void Update() {
        Vector3 targetPosition;
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            if (m_HUD.GetComponent<HUDController>().GetMode() == 0) {
                if (moveCoroutine != null) {
                    StopCoroutine(moveCoroutine);
                }
                wall = false;
                moveCoroutine = StartCoroutine(MoveTo(targetPosition));
            }
        }

       
        
    }
    #endregion

    #region Movement Methods
    private void ScaleY() {
        float scale = 1.0f - (0.25f * (transform.position.y + 2.0f));
        transform.localScale = new Vector3(scale * p_XScale, scale * p_YScale, 1);
    }

    IEnumerator MoveTo(Vector3 target) {
        Rigidbody2D myBody = this.gameObject.GetComponent<Rigidbody2D>();
        while ((target - this.gameObject.transform.position).magnitude > 0.1 && !wall) {
            if (m_HUD.GetComponent<HUDController>().GetMode() != 0) {
                myBody.velocity = Vector3.zero;
            }
            Vector3 vdir = (target - this.gameObject.transform.position).normalized;
            myBody.velocity =vdir * m_MoveSpeed;
            ScaleY();
            yield return null;
        }
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Wall") {
            wall = true;
        }
    }
    #endregion
}
