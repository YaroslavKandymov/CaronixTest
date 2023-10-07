using System;
using UnityEngine;

namespace CaronixTest.EnemyComponents
{
    public class ClickMechanic : MonoBehaviour
    {
        public event Action Clicked;
        
        private void OnMouseDown()
        {
            Clicked?.Invoke();
        }
    }
}