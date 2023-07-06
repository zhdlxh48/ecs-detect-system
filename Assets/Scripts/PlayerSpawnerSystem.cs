using Unity.Entities;

public partial class PlayerSpawnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var playerEntityQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));

        var playerSpawner = SystemAPI.GetSingleton<PlayerSpawner>();
        var randomGenerator = SystemAPI.GetSingletonRW<RandomGenerator>();

        var entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
            .CreateCommandBuffer(World.Unmanaged);
        
        if (playerEntityQuery.CalculateEntityCount() < playerSpawner.Count)
        {
            var spawnedEntity = entityCommandBuffer.Instantiate(playerSpawner.PlayerPrefab);
            entityCommandBuffer.SetComponent(spawnedEntity, new Speed()
            {
                Value = randomGenerator.ValueRW.Random.NextFloat(1f, 5f)
            });
        }
    }
}