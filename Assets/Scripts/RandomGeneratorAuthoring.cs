using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RandomGeneratorAuthoring : MonoBehaviour
{
    [field: SerializeField] public uint Seed { get; private set; } = 1;

    private class RandomGeneratorBaker : Baker<RandomGeneratorAuthoring>
    {
        public override void Bake(RandomGeneratorAuthoring authoring)
        {
            var random = new Random(authoring.Seed);
            var data = new RandomGenerator() { Random = random };
            AddComponent(GetEntity(TransformUsageFlags.None), data);
        }
    }
}