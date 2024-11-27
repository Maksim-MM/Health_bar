using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private void Start()
    {
        _slider.value = _health.GetHealthNormalized();
        _health.Damaged.AddListener(ShowHealth);
        _health.Healed.AddListener(ShowHealth);
    }
    
    private void OnDestroy()
    {
        _health.Damaged.RemoveListener(ShowHealth);
        _health.Healed.RemoveListener(ShowHealth);
    }

    private void ShowHealth()
    {
        _slider.value = _health.GetHealthNormalized();
    }
}
