using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isAi;
    [SerializeField] int enemyPoint = 100;

    [SerializeField] int currentHealth = 50;
    [SerializeField] ParticleSystem explosionEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    ScoreKeeper scorekeeper;

    UIDisplay uiDisplay;
    LevelManager levelmanager;
    public int CurrentHealth { get => currentHealth; }

    private void Awake()
    {
        levelmanager = FindObjectOfType<LevelManager>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scorekeeper = FindObjectOfType<ScoreKeeper>();
        uiDisplay = FindObjectOfType<UIDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            damageDealer.Hit();
            PlayHitEffect();
            ShakeCamera();
            TakeDamage(damageDealer.Damage);
            audioPlayer.PlayTakingDamageClip();
        }

    }
    void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        if (!isAi)
        {
            uiDisplay.DisplayHealth(currentHealth);
        }
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isAi)
        {
            scorekeeper.ModifyScore(enemyPoint);
        }
        else
        {
            levelmanager.LoadGameOver();
        }
        Destroy(gameObject);
    }


    void PlayHitEffect()
    {
        ParticleSystem instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }


    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
