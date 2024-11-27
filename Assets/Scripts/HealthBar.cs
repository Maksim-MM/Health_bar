using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    
    private void OnEnable()
    {
        _health.Damaged += ShowHealth;
        _health.Healed += ShowHealth;
    }

    private void OnDisable()
    {
        _health.Damaged -= ShowHealth;
        _health.Healed -= ShowHealth;
    }

    private void Start()
    {
        _slider.value = _health.GetHealthNormalized();
    }

    private void ShowHealth()
    {
        _slider.value = _health.GetHealthNormalized();
    }
}
