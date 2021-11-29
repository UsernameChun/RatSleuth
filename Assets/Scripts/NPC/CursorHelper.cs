using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHelper : MonoBehaviour
{
    /**
     * This piece of code ensures the hover functionality
     */
    public CursorController HUD;
    private bool hover;

    private void OnMouseEnter() {
        hover = true;
        HUD.changeHover(true);
    }

    private void OnMouseExit() {
        hover = false;
        HUD.changeHover(false);
    }

    private void Update() {
        if (hover) {
            Debug.Log("Hovering " + this.gameObject.name);
        }
    }
}
