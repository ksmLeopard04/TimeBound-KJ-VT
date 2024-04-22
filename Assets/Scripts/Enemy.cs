using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    Color myColor;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        myColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
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
    
        StartCoroutine(GotHit());

        health -= damage;
        if(health <= 0)
        {

            StartCoroutine(Defeated());
        }
    }
    IEnumerator Defeated()
    {
         animator.SetTrigger("isDead");

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

    IEnumerator GotHit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(1f);

        gameObject.GetComponent<SpriteRenderer>().color = myColor;


    }



}
