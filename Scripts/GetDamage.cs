using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetDamage : MonoBehaviour
{
    Scene thisScene;
    private void Awake()
    {
        thisScene=SceneManager.GetActiveScene();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {                                                           
        print("g");
        if (collision.rigidbody.CompareTag("player"))             // oyuncuya de�erse   
        {                                                         
            SceneManager.LoadScene(thisScene.name);               // sahneyi ba�tan y�kle 
            print("q");
        }
        
    }
}
