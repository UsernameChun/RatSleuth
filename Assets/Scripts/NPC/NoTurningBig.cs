using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTurningBig : MonoBehaviour
{
    public int checkpoint;
    private PlotMaster plt;

    private void Start() {
        plt = GameObject.FindGameObjectWithTag("plt").GetComponent<PlotMaster>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!plt.checkpoints[checkpoint]) {

            this.gameObject.SetActive(false);
        }
        else {
            this.gameObject.SetActive(true);
        }
        
    }
}
