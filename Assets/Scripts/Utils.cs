using TMPro;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static TextMeshPro CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAlignmentOptions textAlignment = TextAlignmentOptions.Center, int sortingOrder = 5000)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(text, parent, localPosition, fontSize, (Color)color, textAlignment, sortingOrder);
    }

    public static TextMeshPro CreateWorldText(string text, Transform parent, Vector3 localPosition, int fontSize, Color color, TextAlignmentOptions textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMeshPro));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMeshPro textMesh = gameObject.GetComponent<TextMeshPro>();
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.alignment = textAlignment;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    /// <summary>
    /// Returns the mouse position in the world, with z = 0f.
    /// </summary>
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }
}