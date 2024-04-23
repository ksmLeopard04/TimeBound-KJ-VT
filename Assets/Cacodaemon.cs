using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacodaemon : MonoBehaviour
{
    private Transform player;
    private float normalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        normalSpeed = player.GetComponent<PlayerController>().moveSpeed;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().moveSpeed = 0;
            gameObject.transform.parent.GetComponent<EnemyScript>().moveSpeed = 0;
        }
    }

    private void OnDestroy()
    {
        player.GetComponent<PlayerController>().moveSpeed = normalSpeed;
    }
}
