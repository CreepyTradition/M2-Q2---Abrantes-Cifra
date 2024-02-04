using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagTrigger : MonoBehaviour
{
    Scene currentScene;
    string sceneName;
    int sceneIndex;

    private void Update()
    {
        // Get current scene
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        sceneIndex = currentScene.buildIndex;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (sceneName == "MainLoop")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Next Scene!");
                NextLevel();
            }
        }
        else if (sceneName == "MainLoop2")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("End Screen!");
                EndScreen();
            }
        }
    }
    
    void NextLevel()
    {
        if (sceneName != "MainLoop2")
            SceneManager.LoadScene(sceneIndex + 1);
            Debug.Log("Congrats!");
    }

    void EndScreen()
    {
        if (sceneName == "MainLoop2")
            SceneManager.LoadSceneAsync("EndScreen");
            Debug.Log("Congrats! You won the game!");
    }
}
