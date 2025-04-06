namespace WordBuilder
{
    public abstract class UIPresenter<TModel, TView> : IPresenter<TModel, TView>
        where TModel : UIModel
        where TView : UIView
    {
        protected TModel _model;
        protected TView _view;

        public TModel Model => _model;
        public TView View => _view;


        public void Initialize(TModel model, TView view)
        {
            _model = model;
            _view = view;

            OnInitialize();
        }

        private bool _isActive;

        public void Activate()
        {
            if (_isActive)
                return;
            _isActive = true;
            OnActivate();
        }

        public void Deactivate()
        {
            if (!_isActive)
                return;
            _isActive = false;
            OnDeactivate();
        }

        protected abstract void OnInitialize();
        protected abstract void OnActivate();
        protected abstract void OnDeactivate();

    }

}