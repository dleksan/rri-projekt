using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public bool levelActive;
    private bool levelVictory;

    private Castle theCastle;

    public List<EnemyHealthController> activeEnemies = new List<EnemyHealthController>();

    private SimpleEnemySpawner enemySpawner;

    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        theCastle = FindObjectOfType<Castle>();
        enemySpawner = FindObjectOfType<SimpleEnemySpawner>();

        levelActive = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(levelActive)
        {
            if(theCastle.currentHealth<=0)
            {
                levelActive = false;
                levelVictory = false;

                UIController.instance.towerButtons.SetActive(false);
            }
        }

        if(activeEnemies.Count==0 && enemySpawner.amountToSpawn==0)
        {
            levelActive = false;
            levelVictory = true;

           
            UIController.instance.towerButtons.SetActive(false);
        }

        if(!levelActive)
        {                
            UIController.instance.levelFailScreen.SetActive(!levelVictory);
            UIController.instance.levelCompleteScreen.SetActive(levelVictory);

            UIController.instance.CloseTowerUpgradePanel();
        }


        
    }
}
