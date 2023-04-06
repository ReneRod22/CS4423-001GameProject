using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    private bool isTyping = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose) {
            if(dialoguePanel.activeInHierarchy) {
                if(isTyping) {
                    StopCoroutine(Typing());
                    isTyping = false;
                    dialogueText.text = dialogue[index];
                }
                else {
                    NextLine();
                }
            }
            else {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }

    public void zeroText() {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }


    IEnumerator Typing() {
        isTyping = true;
        foreach(char letter in dialogue[index].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        isTyping = false;
    }


    public void NextLine() {
        if(index < dialogue.Length - 1) {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(Typing());
        }
        else {
            zeroText();
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerIsClose = true;
        }
        else {
            zeroText();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerIsClose = false;
            zeroText();
        }
    }
}
