using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRock : MonoBehaviour
{
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Explode()
    {
        GameObject BOMB = Instantiate(bomb, transform.position, Quaternion.identity);
        BOMB.GetComponent<bomb>().timer = 0;
        Destroy(gameObject);
    }
}
