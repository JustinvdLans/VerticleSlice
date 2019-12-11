    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variable for the speed of the character and the rigidbody2D to manage physics
    public float Speed;
    private Rigidbody2D RB2;
    private Animator Anim;
    public bool canwalk=true;
    void Start()
    {
        RB2 = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Instantiate a Horizontal/Vertical variable that get the inputs
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        //Variable that tells where to walk to in a 2D plane
        Vector2 Movement = new Vector2(Horizontal, Vertical);

        //Add the force towards where the previous variable is aiming and addforce(speed)
        if (Horizontal != 0 && Vertical != 0)
        {
            Movement *= 0.81f;
        }
        if (canwalk)
        {
            RB2.AddForce(Movement * Speed / 40, ForceMode2D.Impulse);
        }
        //Set animator based on Vertical Input
        if (Vertical > 0)
        {
            Anim.SetInteger("Vertical", 1);
        } else if (Vertical == 0)
        {
            Anim.SetInteger("Vertical", 0);
        } else if (Vertical < 0)
        {
            Anim.SetInteger("Vertical", -1);
        }
        //Set animator based on Horizontal Input
        if (Horizontal > 0)
        {
            Anim.SetInteger("Horizontal", 1);
        }
        else if (Horizontal == 0)
        {
            Anim.SetInteger("Horizontal", 0);
        }
        else if (Horizontal < 0)
        {
            Anim.SetInteger("Horizontal", -1);
        }
    }
}
