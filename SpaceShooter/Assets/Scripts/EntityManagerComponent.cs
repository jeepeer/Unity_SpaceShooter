using Unity.Entities;

[GenerateAuthoringComponent]
public struct EntityManagerComponent : IComponentData
{
    public Entity entity;
}
