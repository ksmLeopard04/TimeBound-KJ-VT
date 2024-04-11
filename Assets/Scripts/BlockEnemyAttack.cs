using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
        }
    }
}
