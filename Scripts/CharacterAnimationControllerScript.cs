using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationControllerScript : MonoBehaviour
{
    public float JumpForce=4.5f;
    [SerializeField] private float Speed=3;
    private float MoveDirection;                // animasyonu d�nd�rmek i�in
    private SpriteRenderer Spriterend;          // animasyonu d�nd�rmek i�in

    Vector3 konum;
    public GameObject Cam;                             // camera
    bool  jump;                                 //    z�plad� m�
    bool grounded=true;                         //    yerde mi
    Rigidbody2D RB2D;                           //    hareket
    Animator anim;                              //    animasyon

    private void Awake()
    {
        Application.targetFrameRate = 100;
        anim=GetComponent<Animator>();  // caching
    }

    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        Spriterend = GetComponent<SpriteRenderer>();
         
    }

    private void FixedUpdate()
    {
        //hareket
        RB2D.velocity = new Vector2(Speed * MoveDirection, RB2D.velocity.y) ;

        //z�plama
        if (jump==true)
        {
            RB2D.velocity = new Vector2(RB2D.velocity.x, JumpForce);
            jump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        
        // tua� bas�l�rsa h�z ver ve sprite i d�nd�r, ko�ma animasyonu �al��t�r
        if(grounded== true && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                MoveDirection = -1f;
                anim.SetFloat("Speed", 1f);
                Spriterend.flipX = true;

            }                
            else if (Input.GetKey(KeyCode.D))
            {
                MoveDirection = 1f;
                anim.SetFloat("Speed", 1f);
                Spriterend.flipX = false;
            }
        }

        // tu�a bas�lm�yorsa animasyonu durdur
        else if(grounded == true)
        {
            MoveDirection = 0f;
            anim.SetFloat("Speed", 0f);
        }

        //z�pla
        if(grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("Jump");
            anim.SetBool("Grounded", false);
        }

        konum = RB2D.transform.position;            // konum bilgisi al
    }
    private void OnCollisionEnter2D(Collision2D collision)       
    {   // zemine de�iyorsa grounded = true yap z�plamay� bitir ve animasyodnan ��k
        if(collision.gameObject.CompareTag("zemin"))
        {
            anim.SetBool("Grounded", true);
            grounded = true;
        }
        

    }
    private void LateUpdate()
    {
        Cam.transform.position = new Vector3(konum.x, konum.y, konum.z - 1f);     // kamera takip hareketi
    }
}
