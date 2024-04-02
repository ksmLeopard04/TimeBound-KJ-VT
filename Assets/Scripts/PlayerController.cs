using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private Animator animator;
    public GameObject stopwatch;
    public Animator weaponAnimator;
    public static bool canMove;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        timer = 1.034f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                int count = rb.Cast(
                    movementInput,
                    movementFilter,
                    castCollisions,
                    moveSpeed * Time.fixedDeltaTime * collisionOffset);
                if (count == 0)
                {
                    rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
                }
            }
        }
    }
    public void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
        if(movementInput.x != 0)
        {
            movementInput = new Vector2(movementInput.x, 0);
        }
        if(movementInput.y != 0f)
        {
            movementInput = new Vector2(0, movementInput.y);
        }
        if (movementInput != Vector2.zero)
        {
            animator.SetFloat("XInput", movementInput.x);
            animator.SetFloat("YInput", movementInput.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.034)
        {
            canMove = true;
            animator.SetBool("canMove", true);
        }
        else
        {
            canMove = false;
            animator.SetBool("canMove", false);
        }
    }
    public void OnFire()
    {
        if (timer > 1.034)
        {
            timer = 0;
            weaponAnimator.SetFloat("XInput", animator.GetFloat("XInput"));
            weaponAnimator.SetFloat("YInput", animator.GetFloat("YInput"));
            stopwatch.SetActive(true);
            weaponAnimator.SetBool("Attack", true);
            weaponAnimator.SetBool("Extended", false);
        }
    }
    public void OnFire2()
    {
        animator.SetTrigger("swordAttack");
    }
}
