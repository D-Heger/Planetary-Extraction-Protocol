public abstract class GridEntity
{
    public int Priority { get; set; }
    public EntityType EntityType { get; set; }
    public abstract bool CanOccupy();
}
