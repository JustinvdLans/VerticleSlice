using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{

    float dir;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
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
                transform.LookAt(target1);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                Debug.Log("Moving Towards 1");
                break;
            case 2:
                transform.LookAt(target2);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                Debug.Log("Moving Towards 2");
                break;
            case 3:
                transform.LookAt(target3);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                Debug.Log("Moving Towards 3");
                break;
            case 4:
                transform.LookAt(target4);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                Debug.Log("Moving Towards 4");
                break;
            case 5:
                transform.LookAt(target5);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                Debug.Log("Moving Towards 5");
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
        dir = 5;
    }

    IEnumerator NumberGen()
    {
        while (true)
        {
            dir = Random.Range(1, 5);
            yield return new WaitForSeconds(2);
        }
    }
}
