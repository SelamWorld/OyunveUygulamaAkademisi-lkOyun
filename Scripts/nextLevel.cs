using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    Scene thisScene;
    private void Awake()
    {
        thisScene = SceneManager.GetActiveScene();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.rigidbody.CompareTag("player"))        // her kap�ya geldi�idne sonraki leveli y�kle
        {                                                   // sceen indis de�erine g�re yap�laiblir daha iyi olur
            if (thisScene.name == "Scene1")
            {
                SceneManager.LoadScene("Scene2");
            }
            else if (thisScene.name == "Scene2")
            {
                SceneManager.LoadScene("Scene3");
            }
            else if (thisScene.name == "Scene3")
            {
                SceneManager.LoadScene("Finish");
            }
            

        }
    }

    public void startG()
    {
        SceneManager.LoadScene("Scene1");
    }
}
