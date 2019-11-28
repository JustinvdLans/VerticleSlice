using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject[] ProjectileSpawn;
    public int offset;
    private KeyCode key;
    private float Timer = 0.3f;

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Fire(ProjectileSpawn[0]);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Fire(ProjectileSpawn[3]);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Fire(ProjectileSpawn[1]);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Fire(ProjectileSpawn[2]);
            }
    }

    void Fire(GameObject ps)
    {
        if (Timer <= 0)
        {
            GameObject test = Instantiate(Projectile, ps.transform.position, ps.transform.rotation);

            //Check if walking horizontally and then add the right input offset to the projectiles script
            if (Input.GetAxis("Horizontal") >= 0.5 || Input.GetAxis("Horizontal") <= -0.5)
            {
                test.GetComponent<Projectile>().Offset = new Vector2(Input.GetAxis("Horizontal")/5, Input.GetAxis("Vertical")/5);
            }
            //Check if walking Vertically and then add the right input offset to the projectiles script
            if (Input.GetAxis("Vertical") >= 0.5 || Input.GetAxis("Vertical") <= -0.5)
            {
                test.GetComponent<Projectile>().Offset = new Vector2(Input.GetAxis("Horizontal")/5, Input.GetAxis("Vertical")/5);
            }
            Timer = 0.3f;
        }
    }
}
