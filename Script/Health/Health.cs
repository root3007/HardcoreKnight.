using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]private float startingHealth;
    public float currentHealth {get; private set;}
    private bool dead;

    Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>(); 
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if(currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
        }
        else 
        {
            if(!dead)
            {
                //player dead
                anim.SetTrigger("die");
                GetComponent<PlayerController>().enabled = false;
                dead = true;
                SceneManager.LoadScene("GameOver");
            }
            
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    
}
