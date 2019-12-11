using UnityEngine;
using System.Collections.Generic;

public class DoorEntry : MonoBehaviour
{
    public BoxCollider2D bc2d;
    private Animator anim;
    private PlayerStats ps;
    public List<GameObject> Enemylist;

    private void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (Enemylist.Count == 0)
        {
            if (col.transform.tag == Constants.Tags.Player)
            {
                ps = col.transform.GetComponent<PlayerStats>();
                if (ps.Keys > 0)
                {
                    ps.Keys -= 1;
                    Opendoor();
                }
            }
        }
    }

    void Opendoor()
    {
            bc2d.enabled = false;
            anim.SetTrigger("Open");
    }
}
