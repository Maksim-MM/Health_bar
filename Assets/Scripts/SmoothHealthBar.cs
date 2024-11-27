using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Image _barImage;
    [SerializeField] private Image _damagedBarImage;
    [SerializeField] private Health _health;
 
    private float _shrinkDelay = .6f;
    private float _fillDelay = .1f;
    private float _speed = 1f;
    
    private Coroutine _shrinkCoroutine;
    private Coroutine _fillCoroutine;
    
    private void OnEnable()
    {
        _health.Damaged += SetDamageFill;
        _health.Healed += SetCurrentFill;
    }

    private void OnDisable()
    {
        _health.Damaged -= SetDamageFill;
        _health.Healed -= SetCurrentFill;
    }

    private void Start()
    {
        SetBarFill(_health.GetHealthNormalized());
        
        _damagedBarImage.fillAmount = _barImage.fillAmount;
    }

    private void SetCurrentFill()
    {
        if (_fillCoroutine != null)
        {
            StopCoroutine(_fillCoroutine);
        }

        _shrinkCoroutine = StartCoroutine(FillHealthBar());
    }
    
    private void SetBarFill(float healthNormalized)
    {
        _barImage.fillAmount = healthNormalized;
    }

    private void SetDamageFill()
    {
        SetBarFill(_health.GetHealthNormalized());

        if (_shrinkCoroutine != null)
        {
            StopCoroutine(_shrinkCoroutine);
        }

        _shrinkCoroutine = StartCoroutine(ShrinkDamagedBar());
    }

    private IEnumerator FillHealthBar()
    {
        yield return new WaitForSeconds(_fillDelay);

        while (_barImage.fillAmount < _health.GetHealthNormalized())
        {
            _barImage.fillAmount = Mathf.MoveTowards(
                _barImage.fillAmount,
                _health.GetHealthNormalized(),
                _speed * Time.deltaTime);
            yield return null;
        }
        
        _damagedBarImage.fillAmount = _barImage.fillAmount;
    }
    
    private IEnumerator ShrinkDamagedBar()
    {
        yield return new WaitForSeconds(_shrinkDelay);

        while (_damagedBarImage.fillAmount > _barImage.fillAmount)
        {
            _damagedBarImage.fillAmount = Mathf.MoveTowards(
                _damagedBarImage.fillAmount,
                _barImage.fillAmount,
                _speed * Time.deltaTime);
            yield return null;
        }
    }
}