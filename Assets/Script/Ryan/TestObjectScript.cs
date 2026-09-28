using UnityEngine;

public class TestObjectScript : MonoBehaviour
{
    public float health = 10.0f;
    public float maxHealth = 10.0f;
    public EnemyHPBar enemyHPBar;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            enemyHPBar.fillAmount = health / maxHealth;

            TestDamage(1);
            Debug.Log("gg, "  + health + " HP left!");
        }

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

    public void TestDamage(float damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0.0f);
    }
}
