using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainBuilder : MonoBehaviour
{
    public GameObject before;
    public GameObject after;

    public bool isTalkable;
    public PlotMaster plt;
    public int myCheckpoint;

    public void Phase() {
        if (plt.check(myCheckpoint)) {
            before.SetActive(false);
            after.SetActive(true);
        }
    }
}
