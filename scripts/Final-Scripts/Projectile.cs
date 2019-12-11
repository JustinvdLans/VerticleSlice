using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int Speed;
    private Rigidbody2D rb;
    [HideInInspector]
    public Vector3 Offset;
    public bool Status;
    private Animator anim;
    [HideInInspector]
    public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3f);
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (destroy)
        {
            Destroy(gameObject);
        }
        //Convert Vector 2 to vector3 to add to the movement of the projectile
        //horizontal
        rb.velocity = (-this.transform.up + Offset) * Speed;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        /*if (col.transform.tag == Constants.Tags.Enemy||col.transform.tag == Constants.Tags.Environment || col.transform.tag == Constants.Tags.KeyDoor|| col.transform.tag == Constants.Tags.Rocks)
        {
            anim.SetTrigger("HIT");
        }*/
        if (col.transform.tag == Constants.Tags.Enemy)
        {
            Debug.Log("test");
            col.transform.GetComponent<EnemyWalk>().hit(1);
        }
        anim.SetTrigger("HIT");
    }
}
