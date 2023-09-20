using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using Spawners.Runtime.Core.InterfaceAdapters.Presenters;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace Spawners.Runtime.Core.Domain
{
    public abstract class GeneralSpawnerZinstaller<TEntityData, TSpawnedObjectView> : InstanceZinstaller<ISpawner<TEntityData>> where TSpawnedObjectView : IRecyclableObjectView
    {
        [Inject]
        public IObjectPool<IRecyclableObjectView> _objectPool;
        
        protected override ISpawner<TEntityData> GetInitializedClass()
        {
            ISpawnedObjectPresenter<TEntityData, TSpawnedObjectView> spawnedObjectPresenter = GetSpawnerPresenter();

            ISpawnerPresenter<TEntityData> spawnerPresenter = new SpawnerPresenter<TEntityData, TSpawnedObjectView>(_objectPool, spawnedObjectPresenter);
            
            return new Spawner<TEntityData>(spawnerPresenter);
        }

        protected abstract ISpawnedObjectPresenter<TEntityData, TSpawnedObjectView> GetSpawnerPresenter();
    }
}