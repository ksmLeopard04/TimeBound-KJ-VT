using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageSprite : MonoBehaviour
{

    private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;

    private float alphaSet =0.8f;
    private float alphaMultiplier = 0.85f;

    private Transform player;

    private SpriteRenderer SR;
    private SpriteRenderer playerSR;

    private Color color;

    private void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1f, 1f, 1f, alpha);
        SR.color = color;

        if(Time.time >= (timeActivated + activeTime))
        {
            AfterImageGenerator.Instance.AddToPool(gameObject);
        }
    }
}
