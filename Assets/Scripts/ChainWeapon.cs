using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainWeapon : MonoBehaviour
{
    PurpleBot2 bot;
    EnemyScript enemyScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            bot = collision.gameObject.GetComponent<PurpleBot2>();
            enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            if (bot != null)
            {
                collision.gameObject.GetComponent<PurpleBot2>().speed = 0.2f;
                collision.gameObject.GetComponent<PurpleBot2>().slowed = true;
                collision.gameObject.GetComponent<PurpleBot2>().startTimeBtwShots = 3.5f;
                collision.gameObject.GetComponent<PurpleBot2>().timeBtwShots = collision.gameObject.GetComponent<PurpleBot2>().startTimeBtwShots;
            }
            if(enemyScript != null)
            {
                collision.gameObject.GetComponent<EnemyScript>().moveSpeed = 100f;
            }
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
}
