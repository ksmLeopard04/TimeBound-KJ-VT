using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public SpriteRenderer bombSprite;
    [SerializeField] public float delayToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the scale to make the sprite smaller
        transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        StartCoroutine(ExecuteAfterDelay(delayToDestroy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    IEnumerator ExecuteAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
