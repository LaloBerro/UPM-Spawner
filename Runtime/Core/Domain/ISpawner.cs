namespace Spawners.Runtime.Core.Domain
{
    public interface ISpawner<TEntityData>
    {
        void Spawn(TEntityData data);
    }
}