using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetDamage : MonoBehaviour
{
    Scene thisScene;
    public GameObject Player;
    private void Awake()
    {
        thisScene=SceneManager.GetActiveScene();           // cache
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {                                                           
        if (collision.rigidbody.CompareTag("player"))             // oyuncuya deðerse   
        {
            Player.GetComponent<Points>().SetHealth();
            SceneManager.LoadScene(thisScene.name);               // sahneyi baþtan yükle 
            Points.Lives--;     // caný bir azalt
            print(Points.Lives);
            Points.Score = 0;
            
        }
        
    }
}
