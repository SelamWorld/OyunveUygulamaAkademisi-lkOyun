using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetDamage : MonoBehaviour
{
    Scene thisScene;
    private void Awake()
    {
        thisScene=SceneManager.GetActiveScene();           // cache
       
    }

    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {                                                           
        print("g");
        if (collision.rigidbody.CompareTag("player"))             // oyuncuya de�erse   
        {                                                         
            SceneManager.LoadScene(thisScene.name);               // sahneyi ba�tan y�kle 
            Points.Lives--;     // can� bir azalt
            print(Points.Lives);
        }
        
    }
}
