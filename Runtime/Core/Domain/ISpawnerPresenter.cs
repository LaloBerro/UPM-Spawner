namespace Spawners.Runtime.Core.Domain
{
    public interface ISpawnerPresenter<TEntityData>
    {
        void SpawnWithData(TEntityData data);
    }
}