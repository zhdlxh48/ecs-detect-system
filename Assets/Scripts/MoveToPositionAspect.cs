using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity _entity;
    
    private readonly RefRW<LocalTransform> _localTransform;
    private readonly RefRO<Speed> _speed;
    private readonly RefRW<TargetPosition> _targetPosition;

    public void Move(float deltaTime)
    {
        var moveSpeed = deltaTime * _speed.ValueRO.Value;
        var moveDir = math.normalize((float3)_targetPosition.ValueRO.Value - _localTransform.ValueRW.Position) * moveSpeed;
        _localTransform.ValueRW.Position += moveDir;
    }

    public void CheckReachedTargetPosition(RefRW<RandomGenerator> random)
    {
        const float reachedTargetDistance = 0.1f;
        var dist = math.distance(_localTransform.ValueRW.Position, _targetPosition.ValueRO.Value);
        if (dist < reachedTargetDistance)
        {
            _targetPosition.ValueRW.Value = GetRandomPosition(random);
        }
    }

    private static float3 GetRandomPosition(RefRW<RandomGenerator> random)
    {
        return new float3(random.ValueRW.Random.NextFloat(-5f, 5f), 0, random.ValueRW.Random.NextFloat(-5f, 5f));
    }
}