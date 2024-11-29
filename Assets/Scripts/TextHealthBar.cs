using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Init()
    {
        UpdateDisplay();
    }

    protected override void UpdateDisplay()
    {
        _text.text = Health.Value + "/100";
    }
}
