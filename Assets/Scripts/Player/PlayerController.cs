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

    public float Scale;
    public Animator animator;
    public SpriteRenderer render;
    private int health;
    #endregion

    #region Cached References
    private float p_XScale;
    private float p_YScale;
    #endregion

    #region Initialization
    private void Awake() {
        p_XScale = transform.localScale.x;
        p_YScale = transform.localScale.y;
        health = 6;
    }
    #endregion

    #region Update Methods
    private void Update() {
        if(this.gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero) {
            animator.SetBool("isMoving", false);
        }
        Vector3 targetPosition;
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            if (m_HUD.GetComponent<HUDController>().GetMode() == 0) {
                if (moveCoroutine != null) {
                    StopCoroutine(moveCoroutine);
                }
                wall = false;
                
                if ((targetPosition - this.gameObject.transform.position).x < 0) {
                    Debug.Log("flip");
                    render.flipX = true;
                }
                else {
                    render.flipX = false;
                }
                moveCoroutine = StartCoroutine(MoveTo(targetPosition));
                animator.SetBool("isMoving", true);
                animator.SetBool("isPicking", false);
                animator.SetBool("isTalking", false);
            }
        }
        if (m_HUD.GetComponent<HUDController>().GetMode() == 0) {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            this.transform.position += movement * m_MoveSpeed * Time.fixedDeltaTime;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
                animator.SetBool("isMoving", true);
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                render.flipX = true;
            } else if (Input.GetKeyDown(KeyCode.D)) {
                render.flipX = false;
            }
            ScaleY();
        }
    }
    #endregion

    #region Movement Methods
    private void ScaleY() {
        float scale = 1.0f - (Scale * (transform.position.y + 2.0f));
        transform.localScale = new Vector3(scale * p_XScale, scale * p_YScale, 1);
    }

    IEnumerator MoveTo(Vector3 target) {
        
        Rigidbody2D myBody = this.gameObject.GetComponent<Rigidbody2D>();
        while ((target - this.gameObject.transform.position).magnitude > 0.2 && !wall) {
            if (m_HUD.GetComponent<HUDController>().GetMode() != 0) {
                myBody.velocity = Vector3.zero;
                break;
            }
            Vector3 vdir = (target - this.gameObject.transform.position).normalized;
            myBody.velocity = vdir * m_MoveSpeed;
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

    public void takeDamage() {
        health -= 1;
        if (health <= 0) {
            health = 1;
        }
    }

    public int getHealth() {
        return health;
    }
    #endregion
}
