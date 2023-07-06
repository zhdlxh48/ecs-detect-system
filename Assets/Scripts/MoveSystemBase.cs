using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public partial class MoveSystemBase : SystemBase
{
    // TODO: OnStartRunning, OnCreate가 어떨 때 호출되는지, 왜 여기서 GetSingletonRW를 하고 나중에 불러오면 구조적으로 변경이 일어나 문제가 생기는지 알아보기
    // 아마 MoveToPositionAspect의 Move 메소드 안에서 NextFloat을 호출해 랜덤값을 불러옴과 동시에 Random의 내부 구조에 변화가 일어나고,
    // RefRW<RandomGenerator> 구조체가 이전과 달라져 문제가 생기는 것 같음
    protected override void OnUpdate()
    {
        // Single Thread (Main Thread)
        // var random = SystemAPI.GetSingletonRW<RandomGenerator>();
        // foreach (var moveToPosAspect in SystemAPI.Query<MoveToPositionAspect>())
        // {
        //     moveToPosAspect.Move(SystemAPI.Time.DeltaTime);
        //     moveToPosAspect.CheckReachedTargetPosition(random);
        // }
        
        // Multi Thread (Job System)
        // Entities.ForEach((LocalTransform localTf) =>
        // {
        //     var deltaTime = SystemAPI.Time.DeltaTime;
        //     var moveDir = new float3(1 * deltaTime, 0, 0);
        //     localTf.Translate(moveDir);
        // }).ScheduleParallel();
        // If SingleThread, use Run() instead of ScheduleParallel()
    }
}