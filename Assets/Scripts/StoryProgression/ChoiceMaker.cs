using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceMaker : MonoBehaviour
{
    public NPCController controller;
    public int choiceNum;
    public GameObject[] Disabling;
    public GameObject[] Enabling;

    public void Pressed() {
        foreach(var g in Disabling) {
            g.SetActive(false);
        }
        foreach (var g in Enabling) {
            g.SetActive(true);
        }
        foreach (var g in Enabling) {
            g.GetComponent<NPCController>().forceProgression();
        }
    }

    private void Update() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            controller.shrinkMe();
        }
    }

}
