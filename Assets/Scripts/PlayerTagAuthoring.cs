using Unity.Entities;
using UnityEngine;

public class PlayerTagAuthoring : MonoBehaviour
{
    
    
    private class PlayerTagAuthoringBaker : Baker<PlayerTagAuthoring>
    {
        public override void Bake(PlayerTagAuthoring authoring)
        {
            var data = new PlayerTag();
            AddComponent(GetEntity(TransformUsageFlags.None), data);
        }
    }
}