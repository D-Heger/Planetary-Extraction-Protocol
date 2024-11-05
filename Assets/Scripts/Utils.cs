using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Utils : MonoBehaviour
{
    public static TextMeshPro CreateWorldText(
        string text,
        Transform parent = null,
        Vector3 localPosition = default(Vector3),
        int fontSize = 40,
        Color? color = null,
        TextAlignmentOptions textAlignment = TextAlignmentOptions.Center,
        int sortingOrder = 5000
    )
    {
        if (color == null)
            color = Color.white;

        return CreateWorldText(
            text,
            parent,
            localPosition,
            fontSize,
            (Color)color,
            textAlignment,
            sortingOrder
        );
    }

    public static TextMeshPro CreateWorldText(
        string text,
        Transform parent,
        Vector3 localPosition,
        int fontSize,
        Color color,
        TextAlignmentOptions textAlignment,
        int sortingOrder
    )
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMeshPro));
        Transform transform = gameObject.transform;
        TextMeshPro textMesh = gameObject.GetComponent<TextMeshPro>();

        transform.SetParent(parent, false);
        transform.localPosition = localPosition;

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


    /// <summary>
    /// credit: JanikCodes
    /// </summary>
    public static bool IsMouseOverUI()
    {
        // Check if the EventSystem is null, which can happen if the UI system is not initialized
        if (EventSystem.current == null)
        {
            return false;
        }

        // Create a pointer event data object and set its position to the current mouse position
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        // Create a list to store the results of the raycast
        List<RaycastResult> results = new List<RaycastResult>();

        // Perform the raycast using the current mouse position
        EventSystem.current.RaycastAll(eventData, results);

        // If the results list is not empty, it means the mouse is over a UI element
        return results.Count > 0;
    }
}
