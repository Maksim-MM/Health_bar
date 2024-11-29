using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private Image _barImage;
 
    private float _delay = .2f;
    private float _speed = 1f;
    
    private Coroutine _changeCoroutine;

    protected override void Init()
    {
        _barImage.fillAmount = Health.GetNormalized();
    }

    protected override void UpdateDisplay()
    {
        if (_changeCoroutine != null)
        {
            StopCoroutine(_changeCoroutine);
        }

        _changeCoroutine = StartCoroutine(SetFill());
    }

    private IEnumerator SetFill()
    {
        yield return new WaitForSeconds(_delay);

        float targetFill = Health.GetNormalized();

        while (!Mathf.Approximately(_barImage.fillAmount, targetFill))
        {
            _barImage.fillAmount = Mathf.MoveTowards(
                _barImage.fillAmount,
                targetFill,
                _speed * Time.deltaTime);
            yield return null;
        }
    }
}