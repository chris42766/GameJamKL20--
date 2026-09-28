using UnityEngine;
using UnityEngine.UI;

public class HealthBar :MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Image _healthbarSprite;

    public void UpdateHealthBar(float maxHealth,float currentHealth)
    {
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }
}
