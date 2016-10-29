using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    public string myName;
    public Boolean isFront;
    public Animator anim;
    public float speed;
    public Rigidbody2D rigidBody;
    public int standBackHash;
    public int standFrontHash;
    public Transform transform;
    public bool right;
    public bool left;
    // Use this for initialization
    void Start()
    {
        Debug.Log("I am alive and my name is " + myName);
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        speed = 5f;
        left = true;
        right = false;
        isFront = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        AnimateDirection(move);
    }

    void AnimateDirection(Vector3 move)
    {
        if (move.y < 0)
        {
            isFront = true;
            AnimateRun(move);
        }
        if (move.y > 0)
        {
            isFront = false;
            AnimateRun(move);
        }
        if (move.x > 0)
        {
            AnimateRun(move);
            if (left)
            {
                anim.transform.Rotate(new Vector3(0, 1, 0), 180);
                right = true;
                left = false;
            }
        }
        if(move.x < 0){
            AnimateRun(move);
            if(right){
                anim.transform.Rotate(new Vector3(0, 1, 0), 180);
                right = false;
                left = true;
            }
        }
        if(move.x == 0 && move.y == 0){
            if(isFront){
                anim.CrossFade(Animator.StringToHash("Stand_Front"), 0f);
            }
            else
            {
                anim.CrossFade(Animator.StringToHash("Stand_Back"), 0f);
            }
        }
    }

    void AnimateRun(Vector3 move)
    {
        if (isFront)
        {
            anim.CrossFade(Animator.StringToHash("Run_Front"), 0f);
        }
        else
        {
            anim.CrossFade(Animator.StringToHash("Run_Back"), 0f);
        }
    }
}
