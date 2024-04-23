using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xddscript : MonoBehaviour
{
    public GameObject gravitything;
    public GameObject panel;
    public GameObject exitCollider;
    [SerializeField] Transform spawn;
    private void Start()
    {
        GameObject.Find("Player").transform.position = spawn.transform.position;
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
        panel.SetActive(true);

        BGmusic.instance.GetComponent<AudioSource>().mute = true;
        GameObject.Find("Player").GetComponent<PlayerController>().gotSucked = true;
        exitCollider.SetActive(true);

        // Yield for one second
        yield return new WaitForSeconds(5);
        panel.SetActive(false);
        gravitything.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerController>().moveSpeed = 7;

        gameObject.SetActive(false);

    }
}
