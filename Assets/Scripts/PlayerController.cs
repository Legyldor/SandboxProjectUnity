using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    public string myName;
    public Boolean isFront;
    public Animator anim;
    int standBackHash = Animator.StringToHash("Stand_Back");
    int standFrontHash = Animator.StringToHash("Stand_Front");
    public Transform transform;
    public float speed = 50.0F;
    public bool canMove = true;

    // Use this for initialization
    void Start()
    {
        Debug.Log("I am alive and my name is " + myName);
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed;
        }
        

        /*if (move.x > 0)
        {
             anim.SetTrigger(standFrontHash);
         }
        else if (move.x < 0)
         {
             anim.SetTrigger(standBackHash);
         }*/
    }

    /*void OnCollisionEnter2D(Collision2D coll)
    {
        canMove = false;
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        canMove = true;

    }*/
}
