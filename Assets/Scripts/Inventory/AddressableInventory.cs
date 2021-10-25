using System;
using System.Security.Cryptography;
using UnityEngine.AddressableAssets;

namespace UnityEngine.XR.ARFoundation.Samples.Inventory
{
    public class AddressableInventory : MonoBehaviour
    {
        public static AddressableInventory instance;
        public AssetReferenceT<GameObject> exampleModel;
        private void Awake()
        {
            Singleton();
        }
        private void Singleton()
        {
            if (instance == null)
                Destroy(this);
            else
                instance = this;
        }

        public AssetReferenceT<GameObject> GetAddressableModel()
        {
            return exampleModel;
        }
    }
}