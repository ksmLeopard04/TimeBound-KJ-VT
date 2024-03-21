using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ChainWeapon : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Extended", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
