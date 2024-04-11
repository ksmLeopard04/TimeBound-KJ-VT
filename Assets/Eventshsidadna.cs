using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventshsidadna : MonoBehaviour
{
    private GameObject player;
    public GameObject battleMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (xddscript.gotSucked)
        {
            player = GameObject.Find("Player");
            player.transform.position = gameObject.transform.position;
            battleMusic.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
