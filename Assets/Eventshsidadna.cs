using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventshsidadna : MonoBehaviour
{
    private GameObject player;
    public GameObject enemy;
    public Transform enemySpawn;
    public GameObject battleMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().gotSucked == true)
        {
            player = GameObject.Find("Player");
            enemy.SetActive(true);
            player.transform.position = gameObject.transform.position;
            battleMusic.SetActive(true);
        }
    }
}
