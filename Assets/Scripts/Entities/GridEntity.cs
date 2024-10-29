public abstract class GridEntity
{
    public EntityType EntityType { get; set; }
    public abstract bool CanOccupy();
}
