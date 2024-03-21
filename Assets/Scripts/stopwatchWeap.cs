using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class stopwatchWeap : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public GameObject stopwatch;
    public float distance = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // You can replace this condition with your own trigger
        {
            SpawnPrefab();
        }
    }

    void SpawnPrefab()
    {
        // Get the front of the object
        Vector3 objectFront = transform.position + transform.forward * distance;

        // Instantiate the prefab at the front of the object
        Instantiate(prefabToInstantiate, objectFront, Quaternion.identity);
    }
}
