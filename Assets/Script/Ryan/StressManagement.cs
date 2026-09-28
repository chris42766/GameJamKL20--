using UnityEngine;

public class StressManagement : MonoBehaviour
{
    public float health = 1.0f;
    public float maxHealth = 100.0f;
    public EnemyHPBar enemyHPBar;

    public AddPlayAreaScript addPlayAreaScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        addPlayAreaScript = GameObject.FindGameObjectWithTag("TestTag").GetComponent<AddPlayAreaScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 100)
        {
            Debug.Log("ALRIGHT, VRO; YOU DIED!!!!!");
        }
        
        
        
        /*
        if (Input.GetMouseButtonDown(1))
        {
            //Yes, I do, it's so obvious.

            GetStressed(1);
        }

        */
        
        
        /*
        if (addPlayAreaScript.cardPlayed==2 && !addPlayAreaScript.stopLoop)
        {
            

            TestDamage(addPlayAreaScript.finalAnswer);
            Debug.Log("gg, "  + health + " HP left!");

            enemyHPBar.fillAmount = health / maxHealth;
            Debug.Log("fill amount: " + enemyHPBar.fillAmount);
            //addPlayAreaScript.cardPlayed = 0;
        }
        */

        /*
        if (health <= 0)
        {

            Debug.Log("Spawn a new enemy; restore HP.");
            health = maxHealth;

            enemyHPBar.fillAmount = health;

            Debug.Log("health = " + health);
            Debug.Log("enemyHPBar.fillAmount = " + enemyHPBar.fillAmount);

        }
        */
    }
    public void GetStressed(float damage)
    {
        health = Mathf.Max(health + damage, 0f);
        enemyHPBar.fillAmount = health / maxHealth;
        Debug.Log("Took " + damage + ", " + health + " HP left");
    }


    public void StressRelief(float damage)
    {
        health = Mathf.Max(health - damage, 0f);
        enemyHPBar.fillAmount = health / maxHealth;
        Debug.Log("Took " + damage + ", " + health + " HP left");
    }

    public void TakeDamage()
    {
        if (addPlayAreaScript.cardPlayed == 2 && !addPlayAreaScript.stopLoop)
        {
            //TestDamage(addPlayAreaScript.finalAnswer);
            Debug.Log("gg, " + health + " HP left!");

            enemyHPBar.fillAmount = health / maxHealth;
            Debug.Log("fill amount: " + enemyHPBar.fillAmount);
            //addPlayAreaScript.cardPlayed = 0;
        }
    }
}
