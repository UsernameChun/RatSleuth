using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The HUD Controller.")]
    private GameObject m_HUD;

    [SerializeField]
    [Tooltip("Cursors")]
    public Texture2D walk;
    public Texture2D magnify;
    public Texture2D talk;
    public Texture2D item;
    private bool stop;
    #endregion

    #region Methods
    private void Start() {
        Cursor.SetCursor(walk, Vector2.zero, CursorMode.ForceSoftware);
        stop = false;
    }

    private void Update() {
        int mode = m_HUD.GetComponent<HUDController>().GetMode();
        if (!stop) {
            switch (mode) {
                case 0:
                    Cursor.SetCursor(walk, Vector2.zero, CursorMode.ForceSoftware);
                    break;
                case 1:
                    Cursor.SetCursor(magnify, Vector2.zero, CursorMode.ForceSoftware);
                    break;
                case 2:
                    Cursor.SetCursor(talk, Vector2.zero, CursorMode.ForceSoftware);
                    break;
                case 3:
                    Cursor.SetCursor(item, Vector2.zero, CursorMode.ForceSoftware);
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            stop = true;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        }

    }
    #endregion
}
