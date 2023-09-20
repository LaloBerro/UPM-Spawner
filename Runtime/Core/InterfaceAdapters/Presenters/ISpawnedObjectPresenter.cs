namespace Spawners.Runtime.Core.InterfaceAdapters.Presenters
{
    public interface ISpawnedObjectPresenter<TEntityData, TSpawnedObjectView>
    {
        void SetSpawnedObject(TSpawnedObjectView spawnedObjectView, TEntityData data);
    }
}