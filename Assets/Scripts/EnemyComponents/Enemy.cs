using System;
using UnityEngine;

namespace CaronixTest.EnemyComponents
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private ClickMechanic _clickMechanic;

        public ClickMechanic ClickMechanic => _clickMechanic;
        public int Health { get; private set; }

        public event Action HealthChanged;

        public void Init(int maxHealth)
        {
            Health = maxHealth;
        }

        public void Hit(int value)
        {
            Health -= value;
            
            HealthChanged?.Invoke();
        }
    }
}