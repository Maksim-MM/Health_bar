using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;

    protected override void Init()
    {
        _slider.value = Health.GetNormalized();
    }

    protected override void UpdateDisplay()
    {
        _slider.value = Health.GetNormalized();
    }
}
