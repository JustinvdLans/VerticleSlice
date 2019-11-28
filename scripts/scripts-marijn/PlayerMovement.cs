    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variable for the speed of the character and the rigidbody2D to manage physics
    public float Speed;
    private Rigidbody2D RB2;
    void Start()
    {
        RB2 = GetComponent<Rigidbody2D>();
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
        RB2.AddForce(Movement * Speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == Constants.Tags.KeyDoor)
        {
            gameObject.GetComponent<PlayerStats>().Keys -= 1;
            Destroy(col.gameObject);
        }
    }
}
