using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{

    float dir;
    public Transform[] targets;
    float speed = 1f;

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
                Debug.Log("Direction 1");
                break;
            case 2:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                Debug.Log("Direction 2");
                break;
            case 3:
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                Debug.Log("Direction 3");
                break;
            case 4:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                Debug.Log("Direction 4");
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "wall")
        {
            NewDirection();
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
}
