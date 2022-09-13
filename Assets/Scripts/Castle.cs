using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float totalHealth=100f;

    public float currentHealth;

    public Slider healthSlider;

    public Transform[] attackPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;

        healthSlider.maxValue = totalHealth;
        healthSlider.value = currentHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -=  damageToTake;

        if(currentHealth<=0)
        {

            gameObject.SetActive(false);
            currentHealth = 0;
            AudioManager.instance.PlaySFX(7);
        }else
        {
            AudioManager.instance.PlaySFX(5);
        }

        healthSlider.value = currentHealth;
    }
}
