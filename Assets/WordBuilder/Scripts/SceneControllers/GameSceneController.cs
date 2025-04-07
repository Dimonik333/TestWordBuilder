using UnityEngine;

namespace WordBuilder
{
    public sealed class GameSceneController : SceneController
    {
        [SerializeField] private GameField _field;

        protected override void Awake()
        {
            base.Awake();
            RegisterAction(SceneActionLifePoint.BeforeFadeOut, OnBeforeFade);
        }

        private void OnBeforeFade()
        {
            var words = GameManager.GetLevelData();
            _field.Init(words);
        }
    }
}