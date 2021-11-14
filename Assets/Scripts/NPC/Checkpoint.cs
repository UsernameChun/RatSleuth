using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;
    private PlotMaster plt;

    private void Start() {
        plt = PlotMaster.Instance;
    }

    public void passCheckpoint() {
        plt.set(true, index);
    }
}
