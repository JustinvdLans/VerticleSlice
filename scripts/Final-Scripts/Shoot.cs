using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Projectile projectile;
    public GameObject bomb;
    public GameObject[] ProjectileSpawn;
    public int offset;
    private float ShootSpeed = 0.6f;

    // Update is called once per frame
    void Update()
    {
        ShootSpeed -= Time.deltaTime;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameObject.GetComponent<PlayerStats>().Bombs > 0)
            {
                gameObject.GetComponent<PlayerStats>().Bombs -= 1;
                SpawnBomb();
            }
        }
    }

    void Fire(GameObject ps)
    {
        if (ShootSpeed <= 0)
        {
            Projectile projectile2 = Instantiate(projectile, ps.transform.position, ps.transform.rotation) as Projectile;

            //Check if walking horizontally and then add the right input offset to the projectiles script
            if (Input.GetAxis("Horizontal") >= 0.5 || Input.GetAxis("Horizontal") <= -0.5)
            {
                projectile2.Offset = new Vector3(Input.GetAxis("Horizontal")/5, Input.GetAxis("Vertical")/5,0);
            }
            //Check if walking Vertically and then add the right input offset to the projectiles script
            if (Input.GetAxis("Vertical") >= 0.5 || Input.GetAxis("Vertical") <= -0.5)
            {
                projectile2.Offset = new Vector3(Input.GetAxis("Horizontal")/5, Input.GetAxis("Vertical")/5,0);
            }
            ShootSpeed = 0.6f;
        }
    }
    void SpawnBomb()
    {
        Instantiate(bomb, transform.position, Quaternion.identity);
    }
}
