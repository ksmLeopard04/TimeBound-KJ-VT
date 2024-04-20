using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBotProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    private float timer;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Calculate the direction from the bullet to the player
        Vector3 direction = player.position - transform.position;

        // Project the direction onto the x-y plane to remove the z component
        direction.z = 0;

        // Rotate the bullet to face the player on the z axis only
        transform.right = direction.normalized;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            DestroyProjectile();
        }
        transform.position += transform.right * speed * Time.deltaTime;

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player.GetComponent<PlayerController>().isDashing)
            {
                return;
            }
            else
            {
                player.GetComponent<PlayerController>().health += 0.5f;
                DestroyProjectile();
            }
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
