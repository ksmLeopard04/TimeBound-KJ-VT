using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomTalk : MonoBehaviour
{
    public GameObject player;
    public PlayerController controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.gameObject;
            controller = player.GetComponent<PlayerController>();
            if(controller.talkToMom1 == false && controller.gotSucked == false)
            {
                controller.talkToMom1 = true;
            }
            if(controller.talkToMom2 == false && controller.gotSucked == true)
            {
                controller.talkToMom2 = true;
            }
        }
    }
}
