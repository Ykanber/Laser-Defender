using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        if(scoreKeeper != null)
        {
            Destroy(scoreKeeper);
        }
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
       SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitandLoad());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitandLoad()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(2);
    }
}
