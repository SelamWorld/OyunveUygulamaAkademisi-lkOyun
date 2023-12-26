using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_ControllerScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rbody2D;
    public float speed=0.0f;
    public Vector3 konum;
    [SerializeField]
    private GameObject Cam;
    public SpriteRenderer SpRender;
    // Start is called before the first frame update
    void Start()
    {
        rbody2D=GetComponent<Rigidbody2D>();    
        animator=GetComponent<Animator>();
        SpRender=GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        rbody2D.velocity = new Vector2(Input.GetAxis("Horizontal"), 0);       // karakterin hýzý. yavaþ düþer çünkü 0 a eþitliyorsun sürekli 

    }
    // Update is called once per frame
    void Update()
    {
        // animation control
        if (Input.GetAxis("Horizontal")==0)        // input yoksa speet deðiþkenini deðiþtir
        {
            animator.SetFloat("Speed", 0f);
        }
        if(Input.GetAxis("Horizontal")<=-0.01f)
        { 
            SpRender.flipX = true;
            animator.SetFloat("Speed", 1f);
        }
        if (Input.GetAxis("Horizontal") >= 0.01f)
        {
            SpRender.flipX = false;
            animator.SetFloat("Speed", 1f);
        }

                     // animator parametreleri seter ve reseter ile deðiþtirilir
        //transform.position = new Vector3(konum.x + (Time.deltaTime * speed), konum.y,konum.z);  // hareket ettrime, yere düþme yok
         konum = transform.position;
        
    }
    

    private void LateUpdate()
    {
        Cam.transform.position = new Vector3(konum.x, konum.y, konum.z - 1f);     // kamera takip hareketi
    }
}
