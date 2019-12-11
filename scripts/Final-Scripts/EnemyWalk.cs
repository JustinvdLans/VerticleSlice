using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{

    float dir;
    float speed = 1f;
    private int health=3;
    public DoorEntry DE;

    void Start()
    {
        StartCoroutine(NumberGen());
    }

    void Update()
    {
        WalkToPoint();
    }

    void WalkToPoint()
    {
        switch (dir)
        {
            case 1:
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                break;
            case 4:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == Constants.Tags.Environment|| coll.transform.tag == Constants.Tags.Rocks)
        {
            NewDirection();
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.transform.tag == Constants.Tags.Player)
        {
            PlayerStats playstats = col.transform.GetComponent<PlayerStats>();
            playstats.Hit(1);
        }
    }

    void NewDirection()
    {
        Debug.Log("Nieuwe positie");
        dir -= 2;
        if(dir == 0)
        {
            dir = 4;
        }
        if(dir == -1)
        {
            dir = 3;
        }
    }

    IEnumerator NumberGen()
    {
        while (true)
        {
            dir = Random.Range(1, 5);
            yield return new WaitForSeconds(3);
        }
    }
    public void hit(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            DE.Enemylist.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
