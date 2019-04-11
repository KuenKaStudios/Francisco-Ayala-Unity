using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Move Things
    [Range(0, 10)]
    public float velocity;
    private Animator m_Anim;
    private SpriteRenderer SR;

    //Jump Things
    [Range (0,4)]
    public float jumpForce;
    private Rigidbody2D m_RB;
    private bool canJump;
    public KeyCode JumpKey;

    //Point
    public int Points;
    public Text textPoints;

    //Audio System
    public AudioSource SFX;
    public AudioClip Jump, Point;

    // Start is called before the first frame update
    void Start()
    {
        Points = 0;
        SR = GetComponent<SpriteRenderer>();
        m_Anim = GetComponent<Animator>();
        m_RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float Xmove = Input.GetAxis("Horizontal");
        float Ymove = Input.GetAxis("Vertical");

        Move(Xmove, Ymove);


        if (Input.GetKeyDown(JumpKey) && canJump)
        {
            SFX.PlayOneShot(Jump);
            m_Anim.SetBool("Jump", true);
            m_RB.AddForce(Vector3.up * jumpForce * 100);
            print("Salta");
            canJump = false;
        }


        if (Xmove == 0)
        {
            m_Anim.SetBool("Running", false);
        }
        else
        {
            m_Anim.SetBool("Running", true);
            if (Xmove > 0)
            {
                SR.flipX = false;
            }
            else
            {
                SR.flipX = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Terrain")
        {
            canJump = true;
            m_Anim.SetBool("Jump", false);
        }
    }

    public void GetPoint(){
        Points++;
        textPoints.text = ("" + Points);
        SFX.PlayOneShot(Point);

    }

    private void Move(float X, float Y)
    {
        transform.Translate(Vector3.right * X * velocity * Time.deltaTime);
    }
}
