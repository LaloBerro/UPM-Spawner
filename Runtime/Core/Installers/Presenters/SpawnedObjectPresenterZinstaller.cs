using Spawners.Runtime.Core.InterfaceAdapters.Presenters;
using ZenjectExtensions.Zinstallers;

namespace Spawners.Runtime.Core.Domain
{
    public abstract class SpawnedObjectPresenterZinstaller<TEntityData, TSpawnedObjectView> : CachedInstanceZinstaller<ISpawnedObjectPresenter<TEntityData, TSpawnedObjectView>>
    {
    }
}