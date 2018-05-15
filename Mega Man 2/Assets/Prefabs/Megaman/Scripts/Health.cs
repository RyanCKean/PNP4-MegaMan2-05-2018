using UnityEngine;
using UnityEngine.UI;

//Name: Anthony Downie
//Date: 3/10/18
//Credit: 
//Purpose: Basic script for health and taking damage

public class Health : MonoBehaviour
{

    public const int maxHealth = 20; //field to hold constant starting value of health
    public int currentHealth = maxHealth; //field to hold current health
    public RectTransform healthBar;

    public void TakeDamage(int amount) //handles taking damage
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }

        //healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y); //keeps health bar updated to players current health
        //Debug.Log("health");

    }
	
}
