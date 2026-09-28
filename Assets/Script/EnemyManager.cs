using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;


public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] enemy;
    public AddPlayAreaScript addPlayArea;

    public StressManagement stressScript;

    public float EnemyHP = 5f;
    public float EnemyDamage = 3f;
    [SerializeField] private Vector3 spawnPos = new Vector3(-14.43f, -27.43f, -7.677f);
    [SerializeField] private Vector3 targetPos = new Vector3(-18.21f, -27.43f, -7.677f);
    [SerializeField] private float slideDuration = 1f;

    private GameObject currentEnemy;
    // Update is called once per frame
    void Start()
    {
        //  EnemyCount = 1;
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {

        int n = Random.Range(0, enemy.Length);
        currentEnemy = Instantiate(enemy[n], spawnPos, Quaternion.Euler(0f,180f,0f));

        stressScript.GetStressed(20);

        var props = currentEnemy.GetComponent<EnemyHealthProperties>();
        props.maxHealth = EnemyHP;
        props.health = EnemyHP;
       props.manager = this;
        addPlayArea.enemyHealth = props;

        StartCoroutine(SlideTo(currentEnemy.transform, targetPos, slideDuration));
        //VertexAttribute props =currentEnemy
    }

    public void EnemyDied()
    {
        EnemyHP += 3f;
        EnemyDamage += 1f;

        stressScript.StressRelief(100);

        SpawnEnemy();
    }
    IEnumerator SlideTo(Transform t, Vector3 target, float duration)
    {
        Vector3 start = t.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (t == null) yield break;   // enemy got destroyed mid-slide
            elapsed += Time.deltaTime;
            t.position = Vector3.Lerp(start, target, elapsed / duration);
            yield return null;
        }

        if (t != null) t.position = target;
        if (t.TryGetComponent(out Levitate lev))
            lev.enabled = true;
    }
}
