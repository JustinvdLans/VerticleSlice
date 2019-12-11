using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float Horizontal;
    private float Vertical;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 moveDir;
    private int speed=2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float Horizontal = Random.Range(-1f, 1f);
        float Vertical = Random.Range(-1f, 1f);
        moveDir = new Vector3(Horizontal, Vertical, 0);
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(moveDir * speed);
        if (Vertical > 0)
        {
            anim.SetInteger("Vertical", 1);
        } else if (Vertical < 0)
        {
            anim.SetInteger("Vertical", -1);
        } else {anim.SetInteger("Vertical", 0);}
        if (Horizontal > 0)
        {
            anim.SetInteger("Horizontal", 1);
        } else if (Horizontal < 0)
        {
            anim.SetInteger("Horizontal", -1);
        } else {anim.SetInteger("Horizontal", 0);}
    }

    void ChangeDirection()
    {
        float Horizontal = Random.Range(-1f, 1f);
        float Vertical = Random.Range(-1f, 1f);
        moveDir = new Vector3(Horizontal, Vertical, 0);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.transform.tag == Constants.Tags.Environment||col.transform.tag== Constants.Tags.Rocks)
        {
            ChangeDirection();
        }
    }
}
