using Zenject;
using ZenjectExtensions.Zinstallers;

namespace Spawners.Runtime.Core.Domain
{
    public abstract class SpawnerZinstaller<TEntityData> : CachedInstanceZinstaller<ISpawner<TEntityData>>
    {
        [Inject]
        private ISpawnerPresenter<TEntityData> _spawnerPresenter;
        
        protected override ISpawner<TEntityData> GetInitializedClass()
        {
            return new Spawner<TEntityData>(_spawnerPresenter);
        }
    }
}