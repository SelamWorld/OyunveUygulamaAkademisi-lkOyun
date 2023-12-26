using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int Score=0;
    AudioSource audioS;

    private void Awake()
    {
        audioS=GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectible"))
        {
            Destroy(collision.gameObject);
            Score++;
            audioS.Play();
        }
    }

}
