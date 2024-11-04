using UnityEngine;
using Math = System.Math;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float _currentHealth;

    /// <summary>
    /// Здоровье показывается в процентах, от 0 до 1
    /// </summary>
    public float Health//  Через эту переменную можно получить количество хп
    {
        get
        {
            return _currentHealth / maxHealth;
        }
        private set
        {
            if (_currentHealth + value > maxHealth)
            {
                _currentHealth += value;
            }    
        }
    }
    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    /// <summary>
    ///  Урон расчитывавется в процентах, от 0 до 1
    /// </summary>
    /// <param name="Урон игроку"></param>
    public void TakeDamage(float damage)
    {
        if (damage < 0)
            damage *= -1;
        _currentHealth -= damage * maxHealth;
        if(_currentHealth <= 0)
            playerDead();    
    }

    private void playerDead()
    {
        /*ивент смерти*/
        Debug.Log("Player Dead");
    }
    

}
