using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using Spawners.Runtime.Core.Domain;

namespace Spawners.Runtime.Core.InterfaceAdapters.Presenters
{
    public class SpawnerPresenter<TEntityData, TSpawnedObjectView> : ISpawnerPresenter<TEntityData> where TSpawnedObjectView : IRecyclableObjectView
    {
        private readonly IObjectPool<IRecyclableObjectView> _objectPool;
        private readonly ISpawnedObjectPresenter<TEntityData, TSpawnedObjectView> _spawnedObjectPresenter;

        public SpawnerPresenter(IObjectPool<IRecyclableObjectView> objectPool, ISpawnedObjectPresenter<TEntityData, TSpawnedObjectView> spawnedObjectPresenter)
        {
            _objectPool = objectPool;
            _spawnedObjectPresenter = spawnedObjectPresenter;
        }

        public void SpawnWithData(TEntityData data)
        {
            TSpawnedObjectView spawnedObjectView = (TSpawnedObjectView)_objectPool.GetObject();

            _spawnedObjectPresenter.SetSpawnedObject(spawnedObjectView, data);
        }
    }
}