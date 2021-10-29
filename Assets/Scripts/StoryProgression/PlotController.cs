using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour
{
    public int step;
    public Inspectable[] inspectables0;
    public Talkable[] talkables0;
    public bool[] checklist;
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

    private void Update() {
        if (!checklist[0]) {
            foreach(var x in inspectables0) {
                x.restartConvo();
            }
        }
        if (!checklist[1]) {
            foreach (var x in talkables0) {
                x.restartConvo();
            }
        }
    }

    public void passCheckpoint(int i) {
        checklist[i] = true;
    }

    int getState() {
        return curr;
    }

    bool levelOver() {
        return complete;
    }
}
