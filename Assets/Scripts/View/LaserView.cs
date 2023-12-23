using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Weapon;
using UnityEngine;

namespace Scripts.View
{
    public class LaserView : TransformView
    {
        [SerializeField] private LineRenderer lineRenderer;

        private LaserConfig laserConfig;

        protected override void Awake()
        {
            base.Awake();
        }

        public override void SetEntity(AbstractEntity entity)
        {
            base.SetEntity(entity);
            laserConfig = entity.GetComponent<LaserConfig>();
        }

        protected override void LateUpdate()
        {
            Vector3[] points = new Vector3[2];
            points[0] = new Vector3(laserConfig.Parent.Position.x, laserConfig.Parent.Position.y);
            points[1] = new Vector3(laserConfig.Parent.Position.x, laserConfig.Parent.Position.y) + new Vector3(laserConfig.Parent.Forward.x, laserConfig.Parent.Forward.y) * laserConfig.LaserLength;
            lineRenderer.SetPositions(points);
        }
    }
}

