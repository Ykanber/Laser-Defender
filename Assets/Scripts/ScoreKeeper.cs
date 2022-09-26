using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{

    int currentScore;

    public int CurrentScore { get => currentScore;}

    UIDisplay uiDisplay;

    static ScoreKeeper scoreKeeper;
    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (scoreKeeper != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            scoreKeeper = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        uiDisplay = FindObjectOfType<UIDisplay>();
    }

    public void ModifyScore(int amount)
    {
        currentScore += amount;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        uiDisplay.DisplayScore(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
