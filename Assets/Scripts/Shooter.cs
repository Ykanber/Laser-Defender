using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;
    
    
    [Header("For Bots")]
    [SerializeField] bool useAi;
    [SerializeField] float maxFiringRate = 0.5f;
    [SerializeField] float minFiringRate = 0.3f;


    [HideInInspector] public bool isFiring = false;
    Coroutine firingCoroutine;


    AudioPlayer audioplayer;

    private void Awake()
    {
        audioplayer =  FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAi)
        {
            isFiring = true;
            firingRate = Random.Range(minFiringRate, maxFiringRate);
        }
        
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        do
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(projectile, projectileLifetime);

            audioplayer.PlayShootingClip();
            yield return new WaitForSecondsRealtime(firingRate);
        } while (true);
    }
}
