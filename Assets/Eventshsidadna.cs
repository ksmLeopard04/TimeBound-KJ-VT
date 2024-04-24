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
    public bool fightOver;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        fightOver = false;
    }
    private void Update()
    {
        if (player.GetComponent<PlayerController>().gotSucked == true && !movedToSpawn)
        {
            enemy.SetActive(true);
            player.transform.position = playerTransform.transform.position;
            battleMusic.SetActive(true);
            movedToSpawn = true;
        }
        if (enemy.transform.childCount == 0 && player.GetComponent<PlayerController>().gotSucked == true && fightOver == false)
        {
            battleMusic.SetActive(false);
            BGmusic.instance.GetComponent<AudioSource>().mute = false;
            player.GetComponent<PlayerController>().talkToSelf = true;
            fightOver = true;
        }
    }
}
