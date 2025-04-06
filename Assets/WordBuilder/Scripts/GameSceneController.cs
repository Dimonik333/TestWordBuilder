using UnityEngine;

namespace WordBuilder
{
    public sealed class GameSceneController : SceneController
    {
        [SerializeField] private GameTestStartPoint _startPoint;
        [SerializeField] private GameField _field;

        protected override void Awake()
        {
            base.Awake();
            // �������� ������� � ������ ��� _field

            RegisterAction(SceneActionLifePoint.BeforeFadeOut, () => _startPoint.StartGame());
        }
    }
}