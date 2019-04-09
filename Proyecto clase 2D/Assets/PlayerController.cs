using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Move Things
    [Range(0, 10)]
    public float velocity;
    private Animator m_Anim;
    private SpriteRenderer SR;

    //Jump Things
    [Range(0, 5)]
    public float jumpForce;
    private Rigidbody2D m_RB;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Xmove = Input.GetAxis("Horizontal");
        float Ymove = Input.GetAxis("Vertical");

        Move(Xmove, Ymove);

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

    private void Move(float X, float Y)
    {
        transform.Translate(Vector3.right * X * velocity * Time.deltaTime);
    }
}
