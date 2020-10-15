using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public int sceneNum;

    //Revive spawn;
    public Transform player;
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        //player.transform.rotation = spawn.currentRespawnPoint.rotation;
        //player.Rotate(spawn.currentRespawnPoint.rotation.x, spawn.currentRespawnPoint.rotation.y, spawn.currentRespawnPoint.rotation.z);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSpecificScene()
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

    
