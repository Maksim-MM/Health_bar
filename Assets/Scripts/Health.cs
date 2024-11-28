using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value;
    
    private float _max = 100f;
    private float _min = 0f;
    
    public event UnityAction Changed;
    
    public float ReturnCurrent()
    {
        return _value;
    }
    
    public void TakeDamage(float damage)
    {
        _value -= damage;

        if (_value <= _min)
        {
            _value = _min;
        }
        
        Changed?.Invoke();
    }

    public void TakeCure(float value)
    {
        _value += value;
        
        if (_value > _max)
        {
            _value = _max;
        }
        
        Changed?.Invoke();
    }
    
    public float GetNormalized() 
    {
        return _value / _max;
    }
}
