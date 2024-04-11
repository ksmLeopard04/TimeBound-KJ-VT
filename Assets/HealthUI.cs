using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Sprite[] HealthSprites;
    public Image healthImage;
    public int healthIndex;    

    // Start is called before the first frame update
    void Start()
    {
        healthImage = gameObject.GetComponent<Image>();
        healthIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.sprite = HealthSprites[healthIndex];
    }
}
