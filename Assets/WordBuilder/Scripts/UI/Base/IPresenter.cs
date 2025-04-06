namespace WordBuilder
{
    public interface IPresenter
    {
        void Activate();
        void Deactivate();
    }

    public interface IPresenter<TModel, TView> : IPresenter
        where TModel : IModel
        where TView : IView
    {
        TView View { get; }
        TModel Model { get; }
    }
}