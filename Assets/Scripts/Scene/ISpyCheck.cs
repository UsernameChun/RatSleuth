using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class ISpyCheck : MonoBehaviour
{
    public Checkpoint checkpoint;

    private bool puzzleClear;
    public bool PuzzleClear {
        get {
            return puzzleClear;
        }
    }

    [SerializeField]
    [Tooltip("Which items need to be in the inventory for the puzzle to be complete.")]
    private GameObject[] foundItems;

    public void Update() {
        for (int i = 0; i < foundItems.Length; i++) {
            if (foundItems[i].activeInHierarchy == false) {
                puzzleClear = false;
                break;
            } else {
                puzzleClear = true;
            }
        }

        if (puzzleClear) {
            checkpoint.passCheckpoint();
        }
    }
}
