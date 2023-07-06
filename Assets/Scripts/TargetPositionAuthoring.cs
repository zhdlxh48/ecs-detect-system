using Unity.Entities;
using UnityEngine;

public class TargetPositionAuthoring : MonoBehaviour
{
    [field: SerializeField] public Vector3 Value { get; private set; }

    private class TargetPositionBaker : Baker<TargetPositionAuthoring>
    {
        public override void Bake(TargetPositionAuthoring authoring)
        {
            var data = new TargetPosition() { Value = authoring.Value };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}