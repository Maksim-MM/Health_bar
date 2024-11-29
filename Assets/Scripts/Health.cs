using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float Value { get; private set; }
    
    private float _max = 100f;
    private float _min = 0f;
    
    public event UnityAction Changed;

    public void TakeDamage(float damage)
    {
        Value -= damage;

        if (Value <= _min)
        {
            Value = _min;
        }
        
        Changed?.Invoke();
    }

    public void TakeCure(float value)
    {
        Value += value;
        
        if (Value > _max)
        {
            Value = _max;
        }
        
        Changed?.Invoke();
    }
    
    public float GetNormalized() 
    {
        return Value / _max;
    }
}
