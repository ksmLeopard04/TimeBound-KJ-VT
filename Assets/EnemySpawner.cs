using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject cacoPrefab;

    [SerializeField]
    public GameObject gruntPrefab;

    [SerializeField]
    public GameObject purpleBotPrefab;

    [SerializeField]
    private float cacoInterval = 50f;


    [SerializeField]
    private float gruntInterval = 50f;

    [SerializeField]
    private float purpleBotInterval = 50f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(cacoInterval, cacoPrefab));
        StartCoroutine(spawnEnemy(gruntInterval, gruntPrefab));
        StartCoroutine(spawnEnemy(purpleBotInterval, purpleBotPrefab));
    }

    // Update is called once per frame
    void Update()
    {

       

    }

    IEnumerator spawnEnemy (float interval, GameObject enemy)
    {

        yield return new WaitForSeconds(interval);
        Debug.Log("huh");
        GameObject newEnemy = Instantiate(enemy, (new Vector3(Random.Range(-20f, -6f), Random.Range(-4f, 4.5f), 0)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
