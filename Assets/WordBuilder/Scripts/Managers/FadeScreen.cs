using UnityEngine;

namespace WordBuilder
{
    public sealed class FadeScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _fade;
        public void Show()
        {
            _fade.SetActive(true);
        }
        public void Hide()
        {
            _fade.SetActive(false);
        }
    }
}