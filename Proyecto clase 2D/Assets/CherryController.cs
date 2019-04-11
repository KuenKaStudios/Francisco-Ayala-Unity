using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    private GameObject Player;
    private PlayerController PC;
    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        PC = Player.transform.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            PC.GetPoint();
            m_Animator.SetTrigger("GetItem");
            Destroy(this.gameObject, 0.5f);
            
        }
    }
}
