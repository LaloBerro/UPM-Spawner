using Spawners.Runtime.Core.InterfaceAdapters.Presenters;
using Spawners.Runtime.EmptySpawner.Domain;

namespace Spawners.Runtime.EmptySpawner.InterfaceAdapters.View
{
    public class EmptySpawnedObjectPresenter : ISpawnedObjectPresenter<EmptyData, IEmptyObjectView>
    {
        public void SetSpawnedObject(IEmptyObjectView spawnedObjectView, EmptyData data)
        {
        }
    }
}