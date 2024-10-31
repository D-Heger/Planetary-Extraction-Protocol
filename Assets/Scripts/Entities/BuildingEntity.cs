public class BuildingEntity : GridEntity
{
    public BuildingType BuildingType { get; set; }

    public float CraftingSpeed { get; set; }

    public BuildingEntity(BuildingType buildingType, float craftingSpeed)
    {
        EntityType = EntityType.Building;
        BuildingType = buildingType;
        CraftingSpeed = craftingSpeed;
    }

    public override bool CanOccupy()
    {
        return false;
    }
}
