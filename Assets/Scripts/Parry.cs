using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject projectile;
    public GameObject deflectOrigin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            Instantiate(projectile, deflectOrigin.transform.position, deflectOrigin.transform.rotation);
            GetComponentInParent<PlayerController>().parrySandy = true;
        }
    }
}
