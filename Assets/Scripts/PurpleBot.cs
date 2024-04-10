using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBot : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;

    public DetectionZone zone;

    Rigidbody2D rb;

    [SerializeField]
    Collider2D collider;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //collider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (zone.detectedObjs.Count > 0)
        {
            Vector2 direction = (zone.detectedObjs[0].transform.position - transform.position).normalized;

            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("InRange", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //animator.SetBool("Attacking", false);

    }
}
