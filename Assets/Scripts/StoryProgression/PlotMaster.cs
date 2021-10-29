using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotMaster : MonoBehaviour
{
    public bool[] checkpoints;

    public bool check(int i) {
        if(i < 0 || i >= checkpoints.Length) {
            return false;
        }
        else {
            return checkpoints[i];
        }
    }

    public void set(bool b, int i) {
        checkpoints[i] = b;
    }
}
