using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int Speed;
    private Rigidbody2D rb;
    [HideInInspector]
    public Vector2 Offset;
    private Vector3 Offset2;
    public bool Status;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Convert Vector 2 to vector3 to add to the movement of the projectile
        Offset2.Set(Offset.x, Offset.y, 0);
        //horizontal
        rb.velocity = (-this.transform.up + Offset2) * Speed;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == Constants.Tags.Enemy||col.transform.tag == Constants.Tags.Environment || col.transform.tag == Constants.Tags.KeyDoor)
        {
            Destroy(gameObject);
        }
    }
}
