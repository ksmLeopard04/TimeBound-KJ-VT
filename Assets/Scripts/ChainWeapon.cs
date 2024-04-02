using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ChainWeapon : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void OnEnable()
    {
        animator.SetBool("Extended", true);
    }
    public void LockMovement()
    {
        PlayerController.canMove = !PlayerController.canMove;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
