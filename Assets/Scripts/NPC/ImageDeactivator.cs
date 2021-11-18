using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDeactivator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The collider that the image is associated with.")]
    private GameObject m_Collider;

    void Update() {
        if (!m_Collider.activeInHierarchy) {
            this.gameObject.SetActive(false);
        }
    }
}
