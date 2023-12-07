using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;
    private bool dialogueIsPlaying;
    private static DialogueManager instance;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than 1 Dialogue Manager. That's not bueno.");
        }
        instance = this;
    }

    public static DialogueManager GetInstance(){
        return instance;
    }

    private void Start(){
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update(){
        //return right away if dialogue isn't playing
        if(!dialogueIsPlaying){
            DialogueTrigger playerDialogue = player.GetComponent<DialogueTrigger>();
            playerDialogue.enabled = true;
            return;
        }else{
            DialogueTrigger playerDialogue = player.GetComponent<DialogueTrigger>();
            playerDialogue.enabled = false;
        }

        //handle continuing to next line in dialogue when submit pressed
        //in our case, i'm lazy so i decided to use enter instead
        if(Input.GetKeyDown(KeyCode.Return)){
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkjson){
        currentStory = new Story(inkjson.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode(){
        StartCoroutine(waiter());
    }

    private void ContinueStory(){
        if(currentStory.canContinue){
            dialogueText.text = currentStory.Continue();
        }else{
            ExitDialogueMode();
        }
    }

    IEnumerator waiter(){
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        yield return new WaitForSeconds(3);
        dialogueIsPlaying = false;
    }
}
