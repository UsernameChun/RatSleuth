using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitActivator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The exit indicator to activate.")]
    private GameObject m_ExitIndicator;

    void OnMouseEnter() {
        m_ExitIndicator.SetActive(true);
    }

    void OnMouseExit() {
        m_ExitIndicator.SetActive(false);
    }
}
