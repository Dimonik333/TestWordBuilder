
namespace WordBuilder
{
    public sealed class ActiveGamePresenter : UIPresenter<ActiveGameModel, ActiveGameView>
    {
        protected override void OnActivate()
        {
            _view.CheckButtonClicked += OnCheckButtonClicked;
        }

        protected override void OnDeactivate()
        {
            _view.CheckButtonClicked -= OnCheckButtonClicked;
        }

        protected override void OnInitialize()
        {

        }

        private void OnCheckButtonClicked()
        {
            _model.Check();
        }
    }
}