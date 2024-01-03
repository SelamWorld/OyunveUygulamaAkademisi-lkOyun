using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
    public static int Score=0;
    public static int Lives=3;             // can say�s�
    AudioSource audioS;                    // para toplama sesi
    public TextMeshProUGUI ScoreCanvas;    // Text put n editor
    public Canvas LivesCanvas;             // canvas put in editor

    private void Awake()
    {
        audioS=GetComponent<AudioSource>();     // cache
        SetScore();
        SetHealth();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectible"))
        {
            Score++;          // score artt�r
            Destroy(collision.gameObject);      // paray� yok et         
            audioS.Play();                  // sesi oynat
            SetScore();                      // score u texte yazan fonksiyon
        }
    }

    public void SetScore()        // scoreu texte yazan fonksiyon
    {
        ScoreCanvas.text = "Score: " + Score.ToString();
    }

    public void SetHealth()   // can bar�n� d�zenle
    {
        // lives de�i�kenine g�re can bar� kalplerini sil
        switch (Lives)
        {
            case 0:
                LivesCanvas.transform.GetChild(1).gameObject.SetActive(false);        
                LivesCanvas.transform.GetChild(2).gameObject.SetActive(false);
                LivesCanvas.transform.GetChild(3).gameObject.SetActive(false);
                SceneManager.LoadScene("GameOver");                                      // game Over
                break;
            case 1:
                LivesCanvas.transform.GetChild(2).gameObject.SetActive(false);
                LivesCanvas.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case 2:
                LivesCanvas.transform.GetChild(3).gameObject.SetActive(false);
                break;
            default:
                break;


        }


    }

}
