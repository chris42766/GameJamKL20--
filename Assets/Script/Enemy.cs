using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    [SerializeField] private HealthBar _healthbar;
    private float _currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        _currentHealth = _maxHealth;
        _healthbar.UpdateHealthBar(_maxHealth,_currentHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        _currentHealth -= 0.5f;
        Debug.Log("gg");
    }
}
