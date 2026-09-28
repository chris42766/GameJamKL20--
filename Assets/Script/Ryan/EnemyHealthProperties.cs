using UnityEngine;
using System.Collections;
public class EnemyHealthProperties : MonoBehaviour
{
    public float health = 3.0f;
    public float maxHealth = 3.0f;
    public EnemyHPBar enemyHPBar;

    public AddPlayAreaScript addPlayAreaScript;
    float deathcooldown=2f;
    private bool isDead = false;
    float fallDuration = 0.5f;
    [SerializeField] private float deathDelay = 1.5f;
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
        if (isDead) return;

        health = Mathf.Max(health - damage, 0f);
        enemyHPBar.fillAmount = health / maxHealth;

        if (health <= 0f)
        {
            isDead = true;
            if (TryGetComponent(out Levitate lev))
                lev.enabled = false;

            StartCoroutine(FallRoutine());   // destroys after 1.5 seconds
        }
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
    IEnumerator FallRoutine()
    {
        Quaternion start = transform.rotation;
        Quaternion end = start * Quaternion.Euler(-90f, 0f, 0f);
        float t = 0f;

        while (t < fallDuration)
        {
            t += Time.deltaTime;
            float p = t / fallDuration;
            transform.rotation = Quaternion.Slerp(start, end, p * p);   // starts slow, speeds up like a real fall
            yield return null;
        }

        transform.rotation = end;
        yield return new WaitForSeconds(0.5f);   // stay on the ground briefly

        if (manager != null) manager.EnemyDied();
        Destroy(gameObject);
    }
}
