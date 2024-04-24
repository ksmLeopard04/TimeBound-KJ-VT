using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject player;

    private int index;

    private void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().isDialogue = true;
        player.GetComponent<PlayerController>().movementInput = Vector2.zero;
        StartDialogue();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (gameObject.name == "DialogueBox2" && gameObject.activeSelf)
            {
                SceneManager.LoadScene(0);
            }
            gameObject.SetActive(false);
            player.GetComponent<PlayerController>().isDialogue = false;
        }
    }
}
