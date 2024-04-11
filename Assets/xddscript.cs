using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xddscript : MonoBehaviour
{
    public GameObject gravitything;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            StartCoroutine(MyCoroutine());
        }
    }

    IEnumerator MyCoroutine()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().moveSpeed = 0;
        gravitything.SetActive(true);

        // Yield for one second
        yield return new WaitForSeconds(5);

        gravitything.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerController>().moveSpeed = 7;

    }
}
