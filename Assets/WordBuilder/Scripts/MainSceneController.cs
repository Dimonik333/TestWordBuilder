using UnityEngine;

namespace WordBuilder
{
    public sealed class MainSceneController : SceneController
    {
        [SerializeField] private MainMenu _mainMenu;

        protected override void Awake()
        {
            base.Awake();

            RegisterAction(SceneActionLifePoint.AfterFadeOut, () => _mainMenu.gameObject.SetActive(true));
        }

        private void Start()
        {

        }
    }
}