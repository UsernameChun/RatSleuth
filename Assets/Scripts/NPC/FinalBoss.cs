using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject hook;
    public GameObject Player;
    public float firingFrequency;
    private float timer;
    private bool hit;

    private void Start()
    {
        timer = 0;
        hit = false;
    }
    private void Update()
    {
        if(timer > firingFrequency)
        {
            timer = 0;
            StartCoroutine(shootHim(Player.transform));

        }else
        {
            timer += Time.deltaTime;
        }
    }

    IEnumerator shootHim(Transform tsfm)
    {
        yield return null;
    }

    public bool getHit()
    {
        return hit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            hit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            hit = false;
        }
    }
}
