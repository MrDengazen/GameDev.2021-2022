using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Header("Heath")]
    [SerializeField] private float initializeHealth = 60000f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;

    private Character character;
    public float CurrentHealth { get; set; }
    
    private void Awake()
    {
        CurrentHealth = initializeHealth;
        character = GetComponent<Character>();
        UIManager.Instance.UpdateSessionTime(initializeHealth,CurrentHealth);
    }


    private void Update()
    {
        TakeDamage(1);
    }

    public void TakeDamage(float damage){
        if (CurrentHealth <= 0) {
            return;
        }
        CurrentHealth -= damage;

        if (CurrentHealth<=0){
            Die();
        }
        UIManager.Instance.UpdateSessionTime(CurrentHealth, initializeHealth);
    }

    private void Die(){
        if (character!=null){

        }
        if (destroyObject){
            DestroyObject();
        }
    }

    private void Revive(){

    }

    private void DestroyObject(){

    }
}
