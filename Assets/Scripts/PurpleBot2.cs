using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBot2 : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public float timeBtwShots;
    public float timer;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;
    public bool slowed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (speed == 0.2f)
        {
            if(slowed)
            {
                timer = 4.0f;
                slowed = false;
            }
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if(timer < 0)
            {
                timer = 0;
                speed = 1.5f;
                startTimeBtwShots = 2.7f;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
