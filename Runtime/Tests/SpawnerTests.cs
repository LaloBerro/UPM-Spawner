using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine;
using Spawners.Runtime.Core.Domain;
using Spawners.Runtime.Core.InterfaceAdapters.Presenters;
using Spawners.Runtime.EmptySpawner.Domain;
using Spawners.Runtime.EmptySpawner.InterfaceAdapters.View;
using UnityEngine;
using UnityEngine.TestTools;

namespace Spawner.Runtime.PlayMode.Tests
{
    public class SpawnerTests
    {
        private ISpawner<EmptyData> _spawner;
        private ISpawnerPresenter<EmptyData> _spawnerPresenter;
        private ISpawnedObjectPresenter<EmptyData, IEmptyObjectView> _spawnedObjectPresenter;
        private IObjectPool<IRecyclableObjectView> _objectPool;

        [SetUp]
        public void SetUp()
        {
            GameObject parentGameObject = new GameObject("parent");
            GameObject emptyGameObject = new GameObject("prefab");
            emptyGameObject.AddComponent<EmptyObjectView>();

            IGenerator<IRecyclableObjectView> generator = new RecyclableObjectGenerator(parentGameObject.transform, emptyGameObject);
            _objectPool = new RecyclableObjectPool(generator, 10);
            
            _spawnedObjectPresenter = new EmptySpawnedObjectPresenter();
            
            _spawnerPresenter = new SpawnerPresenter<EmptyData, IEmptyObjectView>(_objectPool, _spawnedObjectPresenter);
            _spawner = new Spawner<EmptyData>(_spawnerPresenter);
        }
        
        [UnityTest]
        public IEnumerator Spawn_EmptyData_SpawnAnObject()
        {
            yield return null;

            //Arrange
            ISpawnerPresenter<EmptyData> spawnerPresenter = Substitute.For<ISpawnerPresenter<EmptyData>>();
            ISpawner<EmptyData> spawner = new Spawner<EmptyData>(spawnerPresenter);

            //Act
            EmptyData emptyData = new EmptyData();
            spawner.Spawn(emptyData);

            //Assert
            spawnerPresenter.Received(1).ShowEntity(emptyData);
        }

        [UnityTest]
        public IEnumerator Spawn_InstantiateAnObject()
        {
            yield return null;

            //Arrange
            EmptyData emptyData = new EmptyData();

            //Act
            _spawner.Spawn(emptyData);

            //Assert
            Assert.Greater(_objectPool.GetPoolSize(), 0);
        }
    }
}