using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health
    {
        set
        {
            Health = value;
        }
    }
    public float health = 10;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Defeated();
        }
    }
    public void Defeated()
    {
        Destroy(gameObject);
    }
}
