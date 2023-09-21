namespace Spawners.Runtime.Core.Domain
{
    public class Spawner<TEntityData> : ISpawner<TEntityData>
    {
        private readonly ISpawnerPresenter<TEntityData> _spawnerPresenter;
        
        public Spawner(ISpawnerPresenter<TEntityData> spawnerPresenter)
        {
            _spawnerPresenter = spawnerPresenter;
        }

        public void Spawn(TEntityData data)
        {
            _spawnerPresenter.SpawnWithData(data);
        }
    }
}