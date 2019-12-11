using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    //[HideInInspector]
    public float timer=4;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            Destroy(gameObject,0.03f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col);
        if (col.transform.tag == Constants.Tags.Rocks)
        {
            if (col.transform.GetComponent<BombRock>() != null)
            {
                col.transform.GetComponent<BombRock>().Explode();
            } else
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
        if (col.transform.tag == Constants.Tags.Enemy)
        {
            EnemyWalk temp = col.gameObject.GetComponent<EnemyWalk>();
            temp.hit(10);
        }
    }
}
