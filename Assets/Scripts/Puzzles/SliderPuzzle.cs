using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPuzzle : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The game object that represents the empty space on the board.")]
    private Transform m_EmptySpace = null;

    [SerializeField]
    [Tooltip("An array of SliderSlide objects that regulate the game logic.")]
    private SliderSlide[] m_Tiles;

    [SerializeField]
    [Tooltip("The checkpoint to pass once the puzzle is solved.")]
    private Checkpoint m_Ckpt;

    private Camera mainCam;
    private int emptySpaceIndex;

    void Start() {
        mainCam = Camera.main;
        emptySpaceIndex = m_Tiles.Length - 1;
        int shuffleCount = 0;
        do {
            Shuffle();
            shuffleCount++;
        } while (GetInversions() % 2 != 0);
        Debug.Log("Shuffle completed after " + shuffleCount + " attempts.");
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit) {
                Debug.Log(hit.transform.name + " hit");

                if (Vector2.Distance(m_EmptySpace.position, hit.transform.position) <= 2.1f) {
                    SliderSlide sliderScript = hit.transform.GetComponent<SliderSlide>();

                    Vector2 tmp = m_EmptySpace.position;
                    m_EmptySpace.position = sliderScript.targetPos;
                    sliderScript.targetPos = tmp;

                    int tileIndex = findIndex(sliderScript);
                    m_Tiles[emptySpaceIndex] = m_Tiles[tileIndex];
                    m_Tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;

                    Debug.Log(hit.transform.name + " moved");
                }
            }
        }

        int correct = 0;
        foreach (var t in m_Tiles) {
            if (t != null) {
                if (t.IsCorrect) {
                    correct++;
                }
            }
        }
        if (correct == m_Tiles.Length - 1) {
            if (m_Ckpt != null) {
                m_Ckpt.passCheckpoint();
            }
            Debug.Log("Puzzle completed.");
        }
    }

    public void Shuffle() {
        for (int i = 0; i < m_Tiles.Length; i++) {
            if (m_Tiles[i] != null) {
                var lastPos = m_Tiles[i].targetPos;
                int idx = Random.Range(0, m_Tiles.Length - 1);
                m_Tiles[i].targetPos = m_Tiles[idx].targetPos;
                m_Tiles[idx].targetPos = lastPos;

                var tmp = m_Tiles[i];
                m_Tiles[i] = m_Tiles[idx];
                m_Tiles[idx] = tmp;
            }
        }
    }

    public int findIndex(SliderSlide ss) {
        for (int i = 0; i < m_Tiles.Length; i++) {
            if (m_Tiles[i] != null) {
                if (m_Tiles[i] == ss) {
                    return i;
                }
            }
        }

        return -1;
    }

    public int GetInversions() {
        int invs = 0;
        for (int i =0; i < m_Tiles.Length; i++) {
            int thisInv = 0;
            for (int j = i; j < m_Tiles.Length; j++) {
                if (m_Tiles[j] != null) {
                    if (m_Tiles[i].number > m_Tiles[j].number) {
                        thisInv++;
                    }
                }
            }
            invs += thisInv;
        }
        return invs;
    }
}
