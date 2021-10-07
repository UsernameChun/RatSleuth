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
    private void FixedUpdate() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        this.transform.position += movement * m_MoveSpeed * Time.fixedDeltaTime;
        ScaleY();
        if (m_HUD.GetComponent<HUDController>().IsMoveMode()) {
            // do something
        }
    }
    #endregion

    #region Movement Methods
    private void ScaleY() {
        float scale = 1.0f - (0.25f * (transform.position.y + 2.0f));
        transform.localScale = new Vector3(scale * p_XScale, scale * p_YScale, 1);
    }
    #endregion
}
