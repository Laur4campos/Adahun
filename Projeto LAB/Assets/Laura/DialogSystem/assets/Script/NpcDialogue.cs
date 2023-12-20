using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour
{
    public string[] dialogueNpc;
    public int dialogueIndex;

    public GameObject dialoguePanel;
    public Text dialogueText;

    public Text nameNpc;
    public Image imageNpc;
    public Sprite spriteNpc;

    public bool readyToSpeak;
    public bool startDialogue;

    void Start()
    {
        dialoguePanel.SetActive(false);
        readyToSpeak = false;
        ClearNpcElements();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && readyToSpeak)
        {
            if (!startDialogue)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueNpc[dialogueIndex])
            {
                NextDialogue();
            }
        }
    }

    void ClearNpcElements()
    {
        nameNpc.text = "";
        imageNpc.sprite = null;
        dialogueText.text = "";
    }

    void NextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex < dialogueNpc.Length)
        {
            StartCoroutine(ShowDialogue());
        }
        else
        {
            EndDialogue();
            dialoguePanel.SetActive(false);
            startDialogue = false;
            dialogueIndex = 0;
        }
    }

    void StartDialogue()
    {
        ClearNpcElements();

        FindObjectOfType<MovimentoDoPlayer>().velocidade = 0f;
        dialoguePanel.SetActive(true);
        nameNpc.text = "Marcos";
        imageNpc.sprite = spriteNpc;
        startDialogue = true;
        dialogueIndex = 0;
        StartCoroutine(ShowDialogue());

    }

    void EndDialogue()
    {       
        dialoguePanel.SetActive(false);
        startDialogue = false;
        dialogueIndex = 0;
        FindObjectOfType<MovimentoDoPlayer>().velocidade = 5f;
        readyToSpeak = false;  // Certifique-se de que o jogador não está mais pronto para falar
        nameNpc.text = "";
        imageNpc.sprite = null;
        ClearNpcElements(); 
    }

    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueNpc[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = true;
            StartDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = false;
        }
    }
}
