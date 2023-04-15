using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float health;
    private const float damage = 1;

    public static event Action<string> OnGameOver;
    public void TakeDamage()
    {
        health -= damage; // Restart the scene to go back to beginning
        if (health < 0)
        {
            OnGameOver?.Invoke("The game is over"); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Car")) // do it using unity events
        {
            TakeDamage();
        }
    }

}
