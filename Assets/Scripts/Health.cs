using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value;
    
    private float _maxHealth = 100f;
    private float _minHealth = 0f;
    
    public event UnityAction Damaged;
    public event UnityAction Healed;
    
    public float ReturnCurrentHealth()
    {
        return _value;
    }
    
    public void TakeDamage(float damage)
    {
        _value -= damage;

        if (_value <= _minHealth)
        {
            _value = _minHealth;
            Die();
        }
        
        Damaged?.Invoke();
    }

    public void TakeCure(float value)
    {
        _value += value;
        
        if (_value > _maxHealth)
        {
            _value = _maxHealth;
        }
        
        Healed?.Invoke();
    }
    
    public float GetHealthNormalized() 
    {
        return _value / _maxHealth;
    }

    private void Die()
    {
        gameObject.SetActive(false);    
    }
}
