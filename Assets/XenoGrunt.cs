using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoGrunt : MonoBehaviour
{
    public GameObject MeeleeAttack;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(xenoAttacking());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator xenoAttacking()
    {
        yield return new WaitForSeconds(5f);
        MeeleeAttack.SetActive(true);
        yield return new WaitForSeconds(1f);
        MeeleeAttack.SetActive(false);
        StartCoroutine(xenoAttacking());
    }
}
