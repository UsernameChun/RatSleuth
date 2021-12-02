using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotMaster : MonoBehaviour
{
    public static PlotMaster Instance {
        get;
        private set;
    }

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
        Debug.Log("Checkpoint " + i + " passed.");
        if (b) {
            skipDialogue(i);
        }
    }

    private void skipDialogue(int i) {
        string tag = "Checkpoint" + i;
        var disables = GameObject.FindGameObjectsWithTag(tag);
        if (disables == null) {
            return;
        }
        foreach(var x in disables){
            x.GetComponent<NPCController>().skipMe();
        }
    }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        for (int i = 0; i < checkpoints.Length; i++) {
            if (checkpoints[i]) {
                skipDialogue(i);
            }
        }
    }
}
