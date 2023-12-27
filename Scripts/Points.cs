using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static int Score=0;
    public static int Lives=3;
    AudioSource audioS;
    public TextMeshProUGUI ScoreCanvas;
    public Canvas LivesScoreCanvas;

    private void Awake()
    {
        audioS=GetComponent<AudioSource>();     // cache
        SetScore();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectible"))
        {
            Score++;          // score arttýr
            Destroy(collision.gameObject);      // parayý yok et         
            audioS.Play();                  // sesi oynat
            SetScore();                      // score u texte yazan fonksiyon
            print(Lives);
        }
    }

    public void SetScore()        // scoreu texte yazan fonksiyon
    {
        ScoreCanvas.text = "Score: " + Score.ToString();
    }

    public void SetHealth()
    {
        //switch (Lives)
        //{
        //    case 0:
        //        ScoreCanvas.

        //}
            
                
    }

}
