using UnityEngine;
using Transform = Asteroids.Core.Transform;

namespace Scripts.View
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TransformView : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer spriteRenderer;
        protected Transform transformObject;

        public Transform TransformObject => transformObject;

        protected virtual void Awake()
        {
            if(spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public virtual void SetTransform(Transform transformObject)
        {
            this.transformObject = transformObject;
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
