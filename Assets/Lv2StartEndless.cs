using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2StartEndless : MonoBehaviour
{
    [SerializeField]
    public GameObject boundary;

    [SerializeField]
    public GameObject spawner;

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
            boundary.SetActive(true);
            spawner.SetActive(true);
        }
    }
}
