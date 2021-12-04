using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDeactivator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The collider that the image is associated with.")]
    private GameObject m_Collider;

    [SerializeField]
    [Tooltip("The dialogue box.")]
    private GameObject m_DiaBox;

    void Update() {
        if (!m_Collider.activeInHierarchy && !m_DiaBox.activeInHierarchy) {
            this.gameObject.SetActive(false);
        }
    }
}
