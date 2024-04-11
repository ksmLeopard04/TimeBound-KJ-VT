using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    public InputAction parryAction;
    Vector2 movementInput;
    Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public bool pressedDown;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private Animator animator;
    public GameObject stopwatch;
    public GameObject sword;
    public GameObject swordHitBox;
    public Animator weaponAnimator;
    public Animator swordAnimator;
    public Animator spearAnimator;
    public Animator shieldAnimator;
    public Animator shieldHoldAnimator;
    public static bool canMove;
    public GameObject panel;
    float timer = 0f;
    float sandyTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        timer = 1.034f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        parryAction.Enable();
    }
    private void OnDisable()
    {
        parryAction.Disable();
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
        if (movementInput.x < -0.5)
        {
            movementInput.x = -1;
        }
        else if (movementInput.x > 0.5)
        {
            movementInput.x = 1;
        }
        else if (-0.5 < movementInput.x && movementInput.x < 0.5)
        {
            movementInput.x = 0;
        }
        if (movementInput.y < -0.5)
        {
            movementInput.y = -1;
        }
        else if (movementInput.y > 0.5)
        {
            movementInput.y = 1;
        }
        else if (-0.5 < movementInput.y && movementInput.y < 0.5)
        {
            movementInput.y = 0;
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
        if (timer > 0.5)
        {
            canMove = true;
            animator.SetBool("canMove", true);
        }
        else
        {
            canMove = false;
            animator.SetBool("canMove", false);
        }
        if(parryAction.IsPressed() && timer > 0.2f)
        {
            timer = 0;
            shieldHoldAnimator.SetBool("isReleased", false);
            if (animator.GetFloat("XInput") != 0 || animator.GetFloat("YInput") != 0)
            {
                shieldHoldAnimator.SetFloat("XInput", animator.GetFloat("XInput"));
                shieldHoldAnimator.SetFloat("YInput", animator.GetFloat("YInput"));
            }
            else
            {
                shieldHoldAnimator.SetFloat("XInput", -1);
                shieldHoldAnimator.SetFloat("YInput", 0);
            }
            shieldHoldAnimator.Play("ShieldHold");
        }
        if(parryAction.WasReleasedThisFrame())
        {
            shieldHoldAnimator.SetBool("isReleased", true);
        }
        sandyTimer += Time.deltaTime;
    }
    public void OnFire()
    {
        if (timer > 1.034)
        {
            timer = 0;
            if (animator.GetFloat("XInput") != 0 || animator.GetFloat("YInput") != 0)
            {
                weaponAnimator.SetFloat("XInput", animator.GetFloat("XInput"));
                weaponAnimator.SetFloat("YInput", animator.GetFloat("YInput"));
            }
            else
            {
                weaponAnimator.SetFloat("XInput", -1);
                weaponAnimator.SetFloat("YInput", 0);
            }
            stopwatch.SetActive(true);
            weaponAnimator.SetBool("Attack", true);
            weaponAnimator.SetBool("Extended", false);
        }
    }
    public void OnFire2()
    {
        if (timer > 0.5)
        {
            timer = 0;
            if (movementInput.x != 0 && movementInput.y != 0)
            {
                if (movementInput.y < 0)
                {
                    if (movementInput.x < 0)
                    {
                        sword.transform.localPosition = new Vector3(0.039f, -0.151f);
                    }
                    else
                    {
                        sword.transform.localPosition = new Vector3(-0.019f, -0.151f);
                    }
                }
                else
                {
                    if (movementInput.x < 0)
                    {
                        sword.transform.localPosition = new Vector3(0.039f, -0.017f);
                    }
                    else
                    {
                        sword.transform.localPosition = new Vector3(-0.019f, -0.017f);
                    }
                }
                swordAnimator.SetFloat("XInput", animator.GetFloat("XInput"));
                swordAnimator.SetFloat("YInput", animator.GetFloat("YInput"));
                swordAnimator.Play("SwordAttack");
            }
            if (animator.GetFloat("XInput") == 0 || animator.GetFloat("YInput") == 0)
            {
                if (animator.GetFloat("YInput") == 0)
                {
                    if (animator.GetFloat("XInput") < 0)
                    {
                        swordHitBox.transform.localPosition = new Vector3(-0.112f, -0.085f);
                        Debug.Log(swordHitBox.transform.position);
                    }
                    else
                    {
                        swordHitBox.transform.localPosition = new Vector3(0.112f, -0.085f);
                    }
                }
                if (animator.GetFloat("XInput") == 0)
                {
                    if (animator.GetFloat("YInput") < 0)
                    {
                        swordHitBox.transform.localPosition = new Vector3(0.016f, -0.179f);
                    }
                    else
                    {
                        swordHitBox.transform.localPosition = new Vector3(0, -0.039f);
                    }
                }
                animator.Play("SwordAttack");
            }
        }
    }
    public void OnFire3()
    {
        if (timer > 0.5)
        {
            timer = 0;
            if (animator.GetFloat("XInput") != 0 || animator.GetFloat("YInput") != 0)
            {
                spearAnimator.SetFloat("XInput", animator.GetFloat("XInput"));
                spearAnimator.SetFloat("YInput", animator.GetFloat("YInput"));
            }
            else
            {
                spearAnimator.SetFloat("XInput", -1);
                spearAnimator.SetFloat("YInput", 0);
            }
            spearAnimator.Play("SpearAttack");
        }
    }
    public void OnParry()
    {
        if (timer > 0.5)
        {
            timer = 0;
            if (animator.GetFloat("XInput") != 0 || animator.GetFloat("YInput") != 0)
            {
                shieldAnimator.SetFloat("XInput", animator.GetFloat("XInput"));
                shieldAnimator.SetFloat("YInput", animator.GetFloat("YInput"));
            }
            shieldAnimator.Play("ShieldParry");
        }
    }
    public void OnSandy()
    {
        if(sandyTimer >= 10f)
        {
            panel.SetActive(true);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
    }
}
