using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public string myName;
    public Boolean isFront;
    public Animator anim;
    public Animation animation;
    public float speed;
    public Rigidbody2D rigidBody;
    public int standBackHash;
    public int standFrontHash;
    public Transform transform;
    public bool right;
    public bool left;
    public bool attack;
    public bool inGravity;
    // Use this for initialization
    void Start()
    {
        Debug.Log("I am alive and my name is " + myName);
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animation>();
        speed = 5f;
        left = true;
        right = false;
        isFront = true;
        attack = false;
        inGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        IsInAttack();

        AnimateDirection(move);

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            AnimateAttack();
        }

        if (inGravity)
        {
            Vector3 forceDirection = transform.position - transform.position;

            // apply force on target towards me
            GetComponent<Rigidbody2D>().AddForce(forceDirection.normalized * 1 * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "TeleportSquare")
        {
            SceneManager.LoadScene("TestGravity");
        }
    }

    void IsInAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_Front") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_Back"))
        {
            this.attack = true;
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
            {
                this.attack = false;
            }
        }
    }

    void AnimateAttack()
    {
        if(isFront){
            Animate("Attack_Front");
        }
        else
        {
            Animate("Attack_Back");
        }
    }

    void Animate(String animName)
    {
        if (!attack)
        {
            anim.CrossFade(Animator.StringToHash(animName), 0f);
        }
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
                AnimateRotate();
                right = true;
                left = false;
            }
        }
        if(move.x < 0){
            AnimateRun(move);
            if(right){
                AnimateRotate();
                right = false;
                left = true;
            }
        }
        if(move.x == 0 && move.y == 0){
            if(isFront){
                Animate("Stand_Front");
            }
            else
            {
                Animate("Stand_Back");
            }
        }
    }

    void AnimateRotate()
    {
        anim.transform.Rotate(new Vector3(0, 1, 0), 180);
    }

    void AnimateRun(Vector3 move)
    {
        if (isFront)
        {
            Animate("Run_Front");
        }
        else
        {
            Animate("Run_Back");
        }
    }
}
