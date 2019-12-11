using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Health { get; set; }
    public int Bombs { get; set; }
    public int Keys { get; set; }
    public int Coins { get; set; }
    private float hittimer =0.3f;
    public Image[] hearts;
    public Sprite[] HeartTypes;
    private Animation anim;
    [HideInInspector]
    public bool died;
    public Text keycounter;
    public Text bombcounter;
    // Start is called before the first frame update
    void Start()
    {
        Health = 4;
        Coins = 5;
        Bombs = 4;
        Keys = 2;
    }

    private void FixedUpdate()
    {
        hittimer -= Time.deltaTime;
        if (died)
        {
            SceneManager.LoadScene(0);
        }
        keycounter.text = "0" + Keys;
        bombcounter.text = "0" + Bombs;
    }

    public void Hit(int dmg)
    {
        Debug.Log("Health: " + Health);
        if (hittimer<0)
        {
            Health -= dmg;
            hittimer = 0.3f;
            Debug.Log("Health: " + Health);
            foreach (Image item in hearts)
            {
                if (item.sprite != HeartTypes[2])
                {
                    if (item.sprite == HeartTypes[0])
                    {
                        item.sprite = HeartTypes[1];
                        break;
                    }
                    else if (item.sprite == HeartTypes[1])
                    {
                        item.sprite = HeartTypes[2];
                        break;
                    }
                    break;
                }
            }
        }
        if (Health <= 0)
        {
            Animator anim = gameObject.GetComponent<Animator>();
            anim.Play("DEAD");
            PlayerMovement player = gameObject.GetComponent<PlayerMovement>();
            player.canwalk = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
