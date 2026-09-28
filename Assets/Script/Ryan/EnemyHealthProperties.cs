using UnityEngine;

public class EnemyHealthProperties : MonoBehaviour
{
    public float health = 3.0f;
    public float maxHealth = 3.0f;
    public EnemyHPBar enemyHPBar;

    public AddPlayAreaScript addPlayAreaScript;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        addPlayAreaScript=GameObject.FindGameObjectWithTag("TestTag").GetComponent<AddPlayAreaScript>();
    }

    // Update is called once per frame
    void Update()
    {
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
    public EnemyManager manager;
    public void ApplyRoundDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0f);
        enemyHPBar.fillAmount = health / maxHealth;

        if (health <= 0f)
        {
            manager.EnemyDied();
            Destroy(gameObject);
        }
        Debug.Log("Took " + damage + ", " + health + " HP left");
    }


    public void AddEnemyHP(float gain)
    {
        health += gain;
        health = Mathf.Max(health, 0.0f);
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
