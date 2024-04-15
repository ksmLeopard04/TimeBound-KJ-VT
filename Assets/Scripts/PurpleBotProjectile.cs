using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PurpleBotProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

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
            player.GetComponent<PlayerController>().health += 1;
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
