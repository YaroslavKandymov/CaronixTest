using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CaronixTest.UI
{
    public class EnemyWindow : Window
    {
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _userName;
        [SerializeField] private TMP_Text _money;
        [SerializeField] private RawImage _rawImage;
        [SerializeField] private Button _searchButton;
        [SerializeField] private Button _fightButton;

        public event Action SearchClicked;
        public event Action FightClicked;
        
        private void OnEnable()
        {
            _searchButton.onClick.AddListener(OnSearchButtonClicked);
            _fightButton.onClick.AddListener(OnFightButtonClicked);
        }

        private void OnDisable()
        {
            _searchButton.onClick.RemoveListener(OnSearchButtonClicked);
            _fightButton.onClick.RemoveListener(OnFightButtonClicked);
        }

        public void InitPlayerName(string username, int money)
        {
            _playerName.text = username;
            _money.text = money.ToString();
        }

        public void ShowEnemy(string username, Texture2D avatar)
        {
            _userName.text = username;
            _rawImage.texture = avatar;
        }

        private void OnSearchButtonClicked()
        {
            SearchClicked?.Invoke();
        }

        private void OnFightButtonClicked()
        {
            FightClicked?.Invoke();
        }
    }
}