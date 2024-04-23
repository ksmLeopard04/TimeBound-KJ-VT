using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;

    public DetectionZone zone;

    Rigidbody2D rb;

    [SerializeField]
    Collider2D collider;

    Animator animator;

    bool isAttacking;

    // Start is called before the first frame update
    void Start()
    { 
        isAttacking = false;
        rb = GetComponent<Rigidbody2D>();
        //collider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {

        }
    }

    private void FixedUpdate()
    {
        if(zone.detectedObjs.Count > 0)
        {
            Vector2 direction = (zone.detectedObjs[0].transform.position - transform.position).normalized;

            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Attacking", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("Attacking", false);

    }

    IEnumerator Attacking()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
