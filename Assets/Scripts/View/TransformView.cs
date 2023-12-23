using Asteroids.Core.ECS;
using UnityEngine;
using Transform = Asteroids.Core.Transform;

namespace Scripts.View
{
    public class TransformView : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer spriteRenderer;

        protected AbstractEntity entity;
        protected Transform transformObject;

        public AbstractEntity Entity => entity;

        protected virtual void Awake()
        {
            if(spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public virtual void SetEntity(AbstractEntity entity)
        {
            this.entity = entity;
            transformObject = entity.GetComponent<Transform>();

            if (transformObject != null)
                spriteRenderer.size = new Vector2(transformObject.Size, transformObject.Size);
        }

        public void SetSprite(Sprite sprite)
        {
            if(spriteRenderer == null)
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
            }

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprite;
            }
        }

        protected virtual void LateUpdate()
        {
            if (transformObject == null)
                return;

            transform.position = new Vector3(transformObject.Position.x, transformObject.Position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, transformObject.Rotation);
        }
    }
}
