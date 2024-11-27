using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _health;

    private void Start()
    {
        ShowHealth();
        
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
        _text.text = _health.ReturnCurrentHealth() + "/100";
    }
}
