using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;
    public PlotMaster plt;

    public void passCheckpoint() {
        plt.set(true, index);
    }
}
