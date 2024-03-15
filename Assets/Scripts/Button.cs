using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    private void Start()
    {
        // Get the Animator component from the object
        animator = GetComponent<Animator>();

    }

    public void PlayAnimation()
    {
        // Trigger the animation
        animator.SetTrigger("PlayAnimation");
    }
}
