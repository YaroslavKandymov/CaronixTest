using CaronixTest.Extensions;
using UnityEngine;

namespace CaronixTest.UI
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        public void Open()
        {
            _canvasGroup.Open();
        }

        public void Close()
        {
            _canvasGroup.Close();
        }
    }
}