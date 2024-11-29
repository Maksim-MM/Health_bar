using UnityEngine;
using UnityEngine.Serialization;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Changed += UpdateDisplay;
    }

    private void OnDisable()
    {
        Health.Changed -= UpdateDisplay;
    }

    private void Start()
    {
        Init();
    }

    protected abstract void Init();
    
    protected abstract void UpdateDisplay();
}