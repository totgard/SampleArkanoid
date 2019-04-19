using System.IO;
using UnityEngine;

namespace Assets.Arkanoid.Scripts
{
    public class GameResourcesProvider : MonoBehaviour
    {
        public static GameResourcesProvider singleton;

        public string DefaultFolder = Application.streamingAssetsPath;

        private AssetBundle _currentBundle;

        private bool IsValidBundle => _currentBundle != null;

        public void LoadBundle(string bundleName)
        {
            if (_currentBundle != null)
            {
                _currentBundle.Unload(true);
            }

            _currentBundle = AssetBundle.LoadFromFile(Path.Combine(DefaultFolder, bundleName));
        }

        public Object LoadObject(string name)
        {
            if (!IsValidBundle)
            {
                throw new System.NullReferenceException("Asset bundle is not loaded");
            }

            return _currentBundle.LoadAsset(name);
        }

        public T LoadObject<T>(string name) where T : Object
        {
            if (!IsValidBundle)
            {
                throw new System.NullReferenceException("Asset bundle is not loaded");
            }

            return _currentBundle.LoadAsset<T>(name);
        }

        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
            else if (singleton != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
