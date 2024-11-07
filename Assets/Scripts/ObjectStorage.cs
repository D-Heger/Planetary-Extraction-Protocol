using UnityEngine;

public class ObjectStorage : MonoBehaviour
{
    private object Obj;

    public void SetObject<T>(T value)
    {
        Obj = value;
    }

    public T GetObject<T>()
    {
        return (T)Obj;
    }
}