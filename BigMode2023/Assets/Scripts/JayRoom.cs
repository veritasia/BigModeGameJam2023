using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class JayRoom : MonoBehaviour
{
    [Header("Ink Jason For Forest of Game")]
    [SerializeField] private TextAsset inkjson;
    private static JayRoom instance;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than 1 Jay Room. That's not bueno.");
        }
        instance = this;
    }

    public static JayRoom GetInstance(){
        return instance;
    }

    public void noMoreRoom(){
        StartCoroutine(sendJayToBrazil());
    }

    IEnumerator sendJayToBrazil(){
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("IntroToGame", LoadSceneMode.Additive);
        while(!asyncload.isDone){
            yield return null;
        }
        SceneManager.UnloadSceneAsync(currentScene);
        DialogueManager.GetInstance().EnterDialogueMode(inkjson);
    }
}
