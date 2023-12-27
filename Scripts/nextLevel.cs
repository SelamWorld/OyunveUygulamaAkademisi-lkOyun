using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    Scene thisScene;
    private void Awake()
    {
       thisScene = SceneManager.GetActiveScene();     // oynadýðýmýz sahneyi cache et
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.rigidbody.CompareTag("player"))        // her kapýya geldiðidne sonraki leveli yükle
        {                                                   // sceen indis deðerine göre yapýlaiblir daha iyi olur
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

    public void startG()            // start butonu
    {
        SceneManager.LoadScene("Scene1");
    }
}
