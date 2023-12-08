using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [Header("Ink Jason")]
    [SerializeField] private TextAsset inkjson;
    private bool playerInRange;

    private void Awake(){
        playerInRange = false;
    }

    private void Update(){
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            if(Input.GetKey(KeyCode.C)){
                DialogueManager.GetInstance().EnterDialogueMode(inkjson);
            }
        }else{
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Interactable"){
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Interactable"){
            playerInRange = false;
        }
    }
}
