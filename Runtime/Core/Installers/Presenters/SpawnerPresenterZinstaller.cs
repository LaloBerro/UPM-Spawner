using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using Spawners.Runtime.Core.InterfaceAdapters.Presenters;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace Spawners.Runtime.Core.Domain
{
    public abstract class SpawnerPresenterZinstaller<TEntityData, TSpawnedObjectView> : InstanceZinstaller<ISpawnerPresenter<TEntityData>> where TSpawnedObjectView : IRecyclableObjectView
    {
        [Inject]
        public IObjectPool<IRecyclableObjectView> _objectPool;
        
        [Inject]
        public ISpawnedObjectPresenter<TEntityData, TSpawnedObjectView> _spawnedObjectPresenter;
        
        protected override ISpawnerPresenter<TEntityData> GetInitializedClass()
        {
            return new SpawnerPresenter<TEntityData, TSpawnedObjectView>(_objectPool, _spawnedObjectPresenter);
        }
    }
}