public class BuildingEntity : GridEntity
{
    public BuildingType BuildingType { get; set; }

    public BuildingEntity(BuildingType buildingType)
    {
        EntityType = EntityType.Building;
        BuildingType = buildingType;
    }

    public override bool CanOccupy()
    {
        return false;
    }
}