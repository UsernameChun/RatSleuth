using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkptEnabler : MonoBehaviour
{
    public int checkpoint;
    public GameObject[] enabling;
    public PlotMaster plt;


    // Update is called once per frame
    void Update()
    {
        if (plt.check(checkpoint)) {
            foreach (var g in enabling) {
                g.SetActive(true);
            }
        }
    }
}
