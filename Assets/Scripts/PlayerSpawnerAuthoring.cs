using Unity.Entities;
using UnityEngine;

public class PlayerSpawnerAuthoring : MonoBehaviour
{
    [field: SerializeField] public int Count { get; private set; }
    
    [field: SerializeField] public GameObject PlayerPrefab { get; private set; }

    private class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
    {
        public override void Bake(PlayerSpawnerAuthoring authoring)
        {
            var data = new PlayerSpawner() { Count = authoring.Count, PlayerPrefab = GetEntity(authoring.PlayerPrefab, TransformUsageFlags.Dynamic) };
            AddComponent(GetEntity(TransformUsageFlags.None), data);
        }
    }
}