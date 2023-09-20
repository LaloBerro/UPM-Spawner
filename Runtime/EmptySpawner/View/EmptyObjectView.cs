using TMPro;
using UnityEngine;

namespace Spawners.Runtime.EmptySpawner.InterfaceAdapters.View
{
    public class EmptyObjectView : MonoBehaviour, IEmptyObjectView
    {
        public void Init()
        {
            gameObject.SetActive(true);
        }

        public void Recycle()
        {
            gameObject.SetActive(false);
        }
    }
}