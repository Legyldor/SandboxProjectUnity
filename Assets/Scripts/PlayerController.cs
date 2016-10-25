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

    // Use this for initialization
    void Start()
    {
        Debug.Log("I am alive and my name is " + myName);
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (move.y < 0)
        {
            anim.CrossFade(Animator.StringToHash("Stand_Front"), 0f);
        }
        else if (move.y > 0)
        {
            anim.CrossFade(Animator.StringToHash("Stand_Back"), 0f);
        }
    }
}
