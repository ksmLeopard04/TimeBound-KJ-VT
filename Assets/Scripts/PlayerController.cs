using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerInstance = null;
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
    public float health;
    public bool gotSucked;
    public bool parrySandy;
    [SerializeField] GameObject BGMusic;
    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    public bool isDashing;

    private void Awake()
    {
        if (playerInstance == null) // If there is not yet a gamemanager then this object
                                    // will be the gamemanager.
        {
            playerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (playerInstance != this) // If there is already a gamemanager then destroy
                                         // this object. There should only ever be one.
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        timer = 1.034f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = 0;
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
                weaponAnimator.SetFloat("XInput", movementInput.x);
                weaponAnimator.SetFloat("YInput", movementInput.y);
                swordAnimator.SetFloat("XInput", movementInput.x);
                swordAnimator.SetFloat("YInput", movementInput.y);
                shieldHoldAnimator.SetFloat("XInput", movementInput.x);
                shieldHoldAnimator.SetFloat("YInput", movementInput.y);
                spearAnimator.SetFloat("XInput", movementInput.x);
                spearAnimator.SetFloat("YInput", movementInput.y);
                shieldAnimator.SetFloat("XInput", movementInput.x);
                shieldAnimator.SetFloat("YInput", movementInput.y);
                int count = rb.Cast(
                    movementInput,
                    movementFilter,
                    castCollisions,
                    moveSpeed * Time.unscaledDeltaTime * collisionOffset);
                if (count == 0)
                {
                    rb.MovePosition(rb.position + movementInput * moveSpeed * Time.unscaledDeltaTime);
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
        if(parrySandy)
        {
            StartCoroutine(Sandy(3));
            parrySandy = false;
        }
        timer += Time.unscaledDeltaTime;
        if (isDashing)
        {
            return;
        }
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
        if (parryAction.IsPressed() && timer > 0.2f)
        {
            timer = 0;
            shieldHoldAnimator.SetBool("isReleased", false);
            shieldHoldAnimator.Play("ShieldHold");
        }
        if (parryAction.WasReleasedThisFrame())
        {
            shieldHoldAnimator.SetBool("isReleased", true);
        }
        GetComponentInChildren<HealthUI>().healthIndex = (int)health;
        if (health >= 4)
        {
            SceneManager.LoadScene("Home");
            health = 0;
            BGMusic.SetActive(true);
            gotSucked = false;
        }
    }
    public void OnFire()
    {
        if (timer > 1.034)
        {
            timer = 0;
            stopwatch.SetActive(true);
            weaponAnimator.SetBool("Attack", true);
            weaponAnimator.SetBool("Extended", false);
        }
    }
    public void OnFire2()
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
    public void OnFire3()
    {

        timer = 0;
        spearAnimator.Play("SpearAttack");
    }
    public void OnParry()
    {
        if (timer > 0.5)
        {
            timer = 0;
            shieldAnimator.Play("ShieldParry");
        }
    }
    public void OnSandy()
    {
        StartCoroutine(Sandy(7f));
    }
    public void OnDash()
    {
        StartCoroutine(Dash());
    }
    private IEnumerator Dash()
    {
        isDashing = true;
        canMove = false;
        rb.velocity = new Vector2(animator.GetFloat("XInput") * dashSpeed, animator.GetFloat("YInput") * dashSpeed);
        if (animator.GetFloat("XInput") == 0 && animator.GetFloat("YInput") == 0)
        {
            rb.velocity = new Vector2(-1 * dashSpeed, 0 * dashSpeed);
        }
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = Vector2.zero;
        canMove = false;
        isDashing = false;
    }
    public IEnumerator Sandy(float sandyTime)
    {
        panel.SetActive(true);
        Time.timeScale = 0.5f;
        animator.speed = animator.speed / 0.5f;
        shieldAnimator.speed = shieldAnimator.speed / 0.5f;
        spearAnimator.speed = spearAnimator.speed / 0.5f;
        weaponAnimator.speed = weaponAnimator.speed / 0.5f;
        swordAnimator.speed = swordAnimator.speed / 0.5f;
        shieldHoldAnimator.speed = shieldAnimator.speed / 0.5f;
        yield return new WaitForSecondsRealtime(sandyTime);
        animator.speed = animator.speed * 0.5f;
        shieldAnimator.speed = shieldAnimator.speed * 0.5f;
        spearAnimator.speed = spearAnimator.speed * 0.5f;
        weaponAnimator.speed = weaponAnimator.speed * 0.5f;
        swordAnimator.speed = swordAnimator.speed * 0.5f;
        shieldHoldAnimator.speed = shieldAnimator.speed * 0.5f;
        Time.timeScale = 1f;
        panel.SetActive(false);
        parrySandy = false;
    }
}
