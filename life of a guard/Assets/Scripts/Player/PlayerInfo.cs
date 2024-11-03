using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }
    /// <summary>
    /// Здоровье показывается в процентах 
    /// </summary>
    public float Health//  Через эту переменную можно получить количество хп
    {
        get
        {
            return _currentHealth / maxHealth * 100f;
        }
        private set
        {
            if (_currentHealth + value > maxHealth)
            {
                _currentHealth += value;
            }    
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            damage *= -1;
        _currentHealth -= damage;
        if(_currentHealth <= 0)
            playerDead();    
    }

    private void playerDead()
    {
        /*ивент смерти*/
    }
    

}
