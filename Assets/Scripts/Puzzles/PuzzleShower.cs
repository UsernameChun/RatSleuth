using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleShower : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The puzzle to display.")]
    private GameObject m_Puzzle;

    public void ShowPuzzle() {
        m_Puzzle.SetActive(true);
    }
}
