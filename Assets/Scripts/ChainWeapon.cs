using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainWeapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<PurpleBot2>().speed = 0.2f;
            collision.gameObject.GetComponent<PurpleBot2>().startTimeBtwShots = 3.5f;
            collision.gameObject.GetComponent<PurpleBot2>().timeBtwShots = collision.gameObject.GetComponent<PurpleBot2>().startTimeBtwShots;
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
}
