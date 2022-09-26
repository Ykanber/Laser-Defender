using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Slider healthSlider;

    int initialHealth;

    private void Awake()
    {
        scoreText.text = "Score: 0";
        healthSlider.value = 1;
    }

    private void Start()
    {
        initialHealth = FindObjectOfType<Player>().GetComponent<Health>().CurrentHealth;
    }

    public void DisplayScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void DisplayHealth(int currentHealth)
    {
        healthSlider.value = (float)currentHealth / initialHealth;
    }

}
