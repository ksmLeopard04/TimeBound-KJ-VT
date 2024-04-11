using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 1.5f;
    float timer = 0;
    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if(timer >= 3f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
        }
    }
}
