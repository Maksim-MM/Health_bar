using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;

    private void OnEnable()
    {
        _health.Changed += UpdateDisplay;
    }

    private void OnDisable()
    {
        _health.Changed -= UpdateDisplay;
    }

    private void Start()
    {
        Init();
    }

    protected abstract void Init();
    
    protected abstract void UpdateDisplay();
}