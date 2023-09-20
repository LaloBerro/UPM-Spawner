namespace Spawners.Runtime.Core.Domain
{
    public interface ISpawnerPresenter<TEntityData>
    {
        void ShowEntity(TEntityData data);
    }
}