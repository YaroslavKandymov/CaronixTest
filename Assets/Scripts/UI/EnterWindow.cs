using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CaronixTest.UI
{
    public class EnterWindow : Window
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _continueButton;

        private string _input;

        public string Value { get; private set; }

        public event Action ContinueClicked;
        
        private void OnEnable()
        {
            _continueButton.onClick.AddListener(OnContinueButtonClicked);
            _inputField.onValueChanged.AddListener(OnInputChanged);
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(OnContinueButtonClicked);
            _inputField.onValueChanged.RemoveListener(OnInputChanged);
        }

        private void Start()
        {
            _continueButton.interactable = false;
        }

        private void OnInputChanged(string value)
        {
            Value = value;
            _continueButton.interactable = value.Length > 0;
        }

        private void OnContinueButtonClicked()
        {
            Close();
            
            ContinueClicked?.Invoke();
        }
    }
}