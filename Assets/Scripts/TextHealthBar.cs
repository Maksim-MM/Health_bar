using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
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
        ShowHealth();
    }

    private void ShowHealth()
    {
        _text.text = _health.ReturnCurrentHealth() + "/100";
    }
}
