using Spawners.Runtime.Core.Domain;
using Spawners.Runtime.Core.InterfaceAdapters.Presenters;
using Spawners.Runtime.EmptySpawner.Domain;
using Spawners.Runtime.EmptySpawner.InterfaceAdapters.View;

namespace Spawners.Runtime.EmptySpawner.Installers
{
    public class EmptySpawnedObjectPresenterZinstaller : SpawnedObjectPresenterZinstaller<EmptyData, IEmptyObjectView>
    {
        protected override ISpawnedObjectPresenter<EmptyData, IEmptyObjectView> GetInitializedClass()
        {
            return new EmptySpawnedObjectPresenter();
        }
    }
}