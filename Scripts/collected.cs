using UnityEngine;
using System.Collections;

public class collected : MonoBehaviour
{

    private playerStats player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<playerStats>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            if (this.gameObject.tag == "RedHearts")
            {

                Destroy(this.gameObject);
                player.health += 10;

            }

            if (this.gameObject.tag == "GoldenHearts")
            {

                Destroy(this.gameObject);
                player.lives += 1;

            }

            if (this.gameObject.tag == "Coin")
            {

                Destroy(this.gameObject);
                FindObjectOfType<playerStats>().score += 5;

            }

            if (this.gameObject.tag == "yellowGem")
            {

                Destroy(this.gameObject);
                FindObjectOfType<playerStats>().score += 10;

            }

            if (this.gameObject.tag == "Thunder")
            {

                Destroy(this.gameObject);
                FindObjectOfType<playerStats>().Thunder += 1;

            }

            if (this.gameObject.tag == "Collectible")
            {
                Destroy(this.gameObject);
                FindObjectOfType<playerStats>().collectible += 1;

            }

            if (this.gameObject.tag == "Evidence")
            {

                Destroy(this.gameObject);
                FindObjectOfType<playerStats>().Evidence += 1;

            }

            if (this.gameObject.tag == "Fire")
            {

                FindObjectOfType<PlayerController>().FirePowerup = true;
                Destroy(this.gameObject);

            }

            if (this.gameObject.tag == "Shield")
            {

                Destroy(this.gameObject);
                FindObjectOfType<playerStats>().IsImmune = true;

            }


        }

    }
}
