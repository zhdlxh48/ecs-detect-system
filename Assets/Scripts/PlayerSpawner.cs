using Unity.Entities;

public struct PlayerSpawner : IComponentData
{
    public int Count;
    
    public Entity PlayerPrefab;
}