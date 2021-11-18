using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTurningBig : MonoBehaviour
{
    public GameObject[] toWatch;

    // Update is called once per frame
    void Update()
    {
        if (toWatch != null) {
            bool b = false;
            foreach(var g in toWatch) {
                if (g.activeInHierarchy) {
                    b = true;
                }
            }
            if (!b) {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }
        }
    }
}
