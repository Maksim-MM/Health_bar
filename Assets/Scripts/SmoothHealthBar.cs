using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Image _barImage;
    [SerializeField] private Image _damagedBarImage;
    [SerializeField] private Health _health;
 
    private float _shrinkDelay = .6f;
    private float _shrinkSpeed = 1f;
    private float _shrinkTimer;
    
    private void Start()
    {
        SetCurrentFill();
        _health.Damaged.AddListener(SetDamageFill);
        _health.Healed.AddListener(SetCurrentFill);
    }
    
    private void Update()
    {
        _shrinkTimer -= Time.deltaTime;

        if (_shrinkTimer <= 0)
        {
            _damagedBarImage.fillAmount = Mathf.MoveTowards(
                _damagedBarImage.fillAmount, 
                _barImage.fillAmount, 
                _shrinkSpeed * Time.deltaTime
            );
        }
    }

    private void OnDestroy()
    {
        _health.Damaged.RemoveListener(SetDamageFill);
        _health.Healed.RemoveListener(SetCurrentFill);
    }
    
    private void SetCurrentFill()
    {
        SetBarFill(_health.GetHealthNormalized());
        _damagedBarImage.fillAmount = _barImage.fillAmount;
    }

    private void SetDamageFill()
    {
        _shrinkTimer = _shrinkDelay;
        SetBarFill(_health.GetHealthNormalized());
    }

    private void SetBarFill(float healthNormalized)
    {
        _barImage.fillAmount = healthNormalized;
    }
}