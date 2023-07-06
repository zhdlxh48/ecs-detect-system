using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpeedAuthoring : MonoBehaviour
{
    [field: SerializeField] public float Value { get; private set; }
    
    private class SpeedBaker : Baker<SpeedAuthoring>
    {
        public override void Bake(SpeedAuthoring authoring)
        {
            var data = new Speed() { Value = authoring.Value };
            // TODO: TransformUsageFlags에 대해 알아보고 Flag에 따라 행동 방식이 어떻게 달라지는지 알아보기
            // https://docs.unity3d.com/Packages/com.unity.entities@1.0/api/Unity.Entities.TransformUsageFlags.html
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}
