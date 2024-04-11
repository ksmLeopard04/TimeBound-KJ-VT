using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsaberguy : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    void Start()
    {

        //collider = GetComponent<CircleCollider2D>();
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("InRange", true);
    }
}
