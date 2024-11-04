public class ObstacleEntity : GridEntity
{
    public ObstacleType ObstacleType { get; set; }

    public ObstacleEntity(ObstacleType obstacleType)
    {
        EntityType = EntityType.Obstacle;
        ObstacleType = obstacleType;
    }
}
