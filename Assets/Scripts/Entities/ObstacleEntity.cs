public class ObstacleEntity : GridEntity
{
    public ObstacleType ObstacleType { get; set; }

    public ObstacleEntity(ObstacleType obstacleType)
    {
        EntityType = EntityType.Obstacle;
        ObstacleType = obstacleType;
    }

    public override bool CanOccupy()
    {
        return false;
    }
}
