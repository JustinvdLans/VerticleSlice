using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int Health { get; set; }
    public int Bombs { get; set; }
    public int Keys { get; set; }
    public int Coins { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Health = 6;
        Coins = 5;
        Bombs = 4;
        Keys = 2;
    }


    public void Hit(int dmg)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
