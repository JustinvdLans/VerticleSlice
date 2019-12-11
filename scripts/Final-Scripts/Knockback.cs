using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public Rigidbody2D rb;
    public float knockback = 100;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Vector2 da = new Vector2(knockback, -knockback);
            rb.AddForce(da, ForceMode2D.Impulse);
        }
    }
}