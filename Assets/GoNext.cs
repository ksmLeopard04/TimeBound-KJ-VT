using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class GoNext : MonoBehaviour
{
    [SerializeField]
    public int SceneNumber;
    public bool goneToScene3;
    [SerializeField] Transform spawn;
    private GameObject[] enemies;
    public GameObject battleMusic;
    public bool hasEnemies;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject.Find("Player").transform.position = spawn.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Grove")
            BGmusic.instance.GetComponent<AudioSource>().Pause();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(SceneNumber);
            GameObject.Find("Player").GetComponent<PlayerController>().goneToScene3 = goneToScene3;
        }

    }
}
