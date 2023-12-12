using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    [Header("Ink Jason For Start of Game")]
    [SerializeField] private TextAsset inkjson;
    [SerializeField] Button startGame;
    [SerializeField] Button continueButton;
    [SerializeField] Button settings;

    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(playGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator actuallyStartGame(){
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("JayRoom", LoadSceneMode.Additive);
        while(!asyncload.isDone){
            yield return null;
        }
        SceneManager.UnloadSceneAsync(currentScene);
        DialogueManager.GetInstance().EnterDialogueMode(inkjson);
    }

    void playGame(){
        StartCoroutine(actuallyStartGame());
    }
}
