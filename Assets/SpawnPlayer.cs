using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public bool movedToSpawn;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().goneToScene3 == true && !movedToSpawn)
        {
            player = GameObject.Find("Player");
            player.transform.position = playerTransform.transform.position;
            movedToSpawn = true;
        }
    }
}
