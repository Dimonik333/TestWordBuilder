
namespace WordBuilder
{
    public sealed class CompletedGamePresenter : UIPresenter<CompletedGameModel, CompletedGameView>
    {
        protected override void OnActivate()
        {
            _view.Text = _model.Text;
            _view.PlayAudio();

            _view.MainMenuButtonClicked += OnMainMenuButtonClicked;
            _view.NextLevelButtonClicked += OnNextLevelButtonClicked;
        }

        protected override void OnDeactivate()
        {
            _view.MainMenuButtonClicked -= OnMainMenuButtonClicked;
            _view.NextLevelButtonClicked -= OnNextLevelButtonClicked;
        }

        protected override void OnInitialize()
        {
            _view.Text = _model.Text;
        }

        private void OnNextLevelButtonClicked()
        {
            _model.NextLevel();
        }

        private void OnMainMenuButtonClicked()
        {
            _model.MainMenu();
        }

    }
}