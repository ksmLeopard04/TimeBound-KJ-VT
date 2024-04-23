using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleeAttack : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Got hit");
            player.GetComponent<PlayerController>().health += 1f;
        }
    }
}
