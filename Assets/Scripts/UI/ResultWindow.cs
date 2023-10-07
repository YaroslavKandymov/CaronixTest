using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CaronixTest.UI
{
    public class ResultWindow : Window
    {
        [SerializeField] private TMP_Text _enemyName;
        [SerializeField] private TMP_Text _money;
        [SerializeField] private Button _continueButton;

        public event Action ContinueClicked;
        
        private void OnEnable()
        {
            _continueButton.onClick.AddListener(OnContinueButtonClicked);
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(OnContinueButtonClicked);
        }

        public void Fill(string username, string money)
        {
            _enemyName.text = username;
            _money.text = money;
        }

        private void OnContinueButtonClicked()
        {
            ContinueClicked?.Invoke();
        }
    }
}