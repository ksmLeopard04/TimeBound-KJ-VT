using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

            GameObject.Find("audio").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("audio").transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();

            gameObject.SetActive(false);
        }
    }

}
