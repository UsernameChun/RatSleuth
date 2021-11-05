using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHelper : MonoBehaviour
{
    /**
     * This piece of code ensures the hover functionality
     */
    public CursorController HUD;

    private void OnMouseEnter() {
        HUD.changeHover(true);
    }

    private void OnMouseExit() {
        HUD.changeHover(false);
    }
}
