using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;

[BurstCompile]
public partial struct MoveISystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }
    
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var random = SystemAPI.GetSingletonRW<RandomGenerator>();
        
        var deltaTime = SystemAPI.Time.DeltaTime;
        var jobHandle = new MoveJob() { DeltaTime = deltaTime }.ScheduleParallel(state.Dependency);
        // Schedule된 Job이 완료될 때까지 기다린 후 CheckReachedTargetPositionJob을 Main Thread에서 실행
        jobHandle.Complete();
        new CheckReachedTargetPositionJob() { Random = random }.Run();
    }

    [BurstCompile]
    private partial struct MoveJob : IJobEntity
    {
        public float DeltaTime;

        public void Execute(MoveToPositionAspect aspect)
        {
            aspect.Move(DeltaTime);
        }
    }
    
    [BurstCompile]
    private partial struct CheckReachedTargetPositionJob : IJobEntity
    {
        [NativeDisableUnsafePtrRestriction] public RefRW<RandomGenerator> Random;

        public void Execute(MoveToPositionAspect aspect)
        {
            aspect.CheckReachedTargetPosition(Random);
        }
    }
}