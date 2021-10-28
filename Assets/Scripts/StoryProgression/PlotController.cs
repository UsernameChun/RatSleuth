using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour
{
    public int step;
    private int curr;
    private bool complete;
    void Start()
    {
        curr = 0;
        complete = false;
    }

    void incr() {
        if (curr < step) {
            curr++;
        }
        else {
            complete = true;
        }
    }

    int getState() {
        return curr;
    }

    bool levelOver() {
        return complete;
    }
}
