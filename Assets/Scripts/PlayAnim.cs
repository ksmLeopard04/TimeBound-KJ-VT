using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private Animation animation;

    void Start()
    {
        animation = GetComponent<Animation>();
        // Play the animation
        animation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
