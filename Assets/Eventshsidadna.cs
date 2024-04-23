using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventshsidadna : MonoBehaviour
{
    private GameObject player;
    public GameObject enemy;
    public Transform enemySpawn;
    public GameObject battleMusic;
    public Transform playerTransform;
    public bool movedToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().gotSucked == true && !movedToSpawn)
        {
            player = GameObject.Find("Player");
            enemy.SetActive(true);
            player.transform.position = playerTransform.transform.position;
            battleMusic.SetActive(true);
            movedToSpawn = true;
        }
        if(enemy.transform.childCount == 0 && GameObject.Find("Player").GetComponent<PlayerController>().gotSucked == true)
        {
            battleMusic.SetActive(false);
            BGmusic.instance.GetComponent<AudioSource>().mute = false;
        }
    }
}
