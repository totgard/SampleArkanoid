using System.Collections.Generic;
using UnityEngine;

namespace Assets.Arkanoid.Scripts
{
    public class LevelCreator : MonoBehaviour
    {
        public Brick Prefab;
        public Transform ContentRoot;

        public int Height = 5;
        public int Widht = 5;

        public int MinBrickHealth = 1;
        public int MaxBrickHealth = 10;

        public bool IsRandom = false;

        public Vector3 Offset = Vector2.zero;
        public Vector3 Spacing = Vector2.zero;

        public List<Brick> Create()
        {
            return Create(Height, Widht, IsRandom);
        }

        public List<Brick> Create(int height, int width, bool isRandom)
        {
            if (Prefab == null)
            {
                var item = GameResourcesProvider.singleton.LoadObject<GameObject>("Brick");
                Prefab = item.GetComponent<Brick>();
            }

            var result = new List<Brick>();

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (isRandom && Random.value < 0.5f)
                    {
                        continue;
                    }

                    var item = Instantiate(Prefab, ContentRoot);
                    var itemPosition = item.transform.localPosition;
                    var itemScale = item.transform.lossyScale * item.Sprite.size;
                    itemPosition.x += j * itemScale.x;
                    itemPosition.y += i * itemScale.y;
                    itemPosition.x += j * itemScale.x * Spacing.x;
                    itemPosition.y += i * itemScale.y * Spacing.y;

                    item.transform.localPosition += itemPosition;
                    item.Health = Random.Range(MinBrickHealth, MaxBrickHealth);
                    result.Add(item);
                }
            }

            return result;
        }

        public void Clear()
        {
            for (var i = 0; i < ContentRoot.childCount; i++)
            {
                Destroy(ContentRoot.GetChild(i).gameObject);
            }
        }
    }
}