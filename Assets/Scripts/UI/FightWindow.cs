using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CaronixTest.UI
{
    public class FightWindow : Window
    {
        [SerializeField] private TMP_Text _username;
        [SerializeField] private Image _health;
        [SerializeField] private float _time;

        public void Init(string username)
        {
            _username.text = username;
        }
        
        public void Restart()
        {
            _health.fillAmount = 1;
        }

        public void ChangeValue(float currentValue, float maxValue)
        {
            var targetValue = currentValue / maxValue;
            
            _health.DOFillAmount(targetValue, _time).SetEase(Ease.Linear);
        }
    }
}