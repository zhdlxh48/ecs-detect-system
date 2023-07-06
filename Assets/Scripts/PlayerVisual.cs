using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerVisual : MonoBehaviour
{
    private Entity _targetEntity;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _targetEntity = GetRandomEntity();
        }
        
        if (_targetEntity != Entity.Null)
        {
            var followPosition = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalToWorld>(_targetEntity).Position;
            transform.position = followPosition;
        }
        else
        {
            _targetEntity = GetRandomEntity();
        }
    }

    private Entity GetRandomEntity()
    {
        var playerTagEntityQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(PlayerTag));
        var entityNativeArray = playerTagEntityQuery.ToEntityArray(Allocator.Temp);

        if (entityNativeArray.Length > 0)
        {
            return entityNativeArray[Random.Range(0, entityNativeArray.Length)];
        }
        else
        {
            return Entity.Null;
        }
    }
}