using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    Vector2 rawInput;

    Vector2 minBounds;
    Vector2 maxBounds;


    Shooter shooter;


    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        InitBounds();
    }


    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0.05f, 0.1f));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(0.95f, 0.5f));
    }

    void Move()
    {
        Vector2 delta = rawInput * Time.deltaTime * moveSpeed;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(delta.x + transform.position.x, minBounds.x, maxBounds.x);
        newPos.y = Mathf.Clamp(delta.y + transform.position.y, minBounds.y, maxBounds.y);
        transform.position = newPos;

    }


    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }        

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

}
