public class ResourceEntity : GridEntity
{
    public ResourceType ResourceType { get; set; }
    public int Amount { get; set; }

    public ResourceEntity(ResourceType resourceType, int amount)
    {
        EntityType = EntityType.Resource;
        ResourceType = resourceType;
        Amount = amount;
    }

    public override bool CanOccupy()
    {
        return false;
    }
}
