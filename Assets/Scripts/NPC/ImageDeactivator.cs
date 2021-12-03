using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDeactivator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The collider that the image is associated with.")]
    private GameObject[] m_Colliders;

    void Update() {
        bool allDisabled = true;

        foreach (var game in m_Colliders) {
            if (game.activeInHierarchy) {
                allDisabled = false;
            }
        }

        if (allDisabled) {
            this.gameObject.SetActive(false);
        }
    }
}
