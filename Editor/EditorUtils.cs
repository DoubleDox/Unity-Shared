using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorUtils
{
    static int[] lineStart = { 0, 1, 3, 2, 0, 1, 3, 2, 4, 5, 7, 6 };
    static int[] lineEnd = { 4, 5, 7, 6, 1, 3, 2, 0, 5, 7, 6, 4 };

    public static Vector3 GetBoxCorner(int p)
    {
        Vector3 res = Vector3.one;

        if ((p & 1) == 1) res.z = -res.z;
        if ((p & 2) == 2) res.y = -res.y;
        if ((p & 4) == 4) res.x = -res.x;
        return res;
    }

    public static void DrawCuboid(Transform parent, Vector3 position, Vector3 size)
    {
        for (int i = 0; i < 12; i++)
        {
            Vector3 start = GetBoxCorner(lineStart[i]);
            start.Scale(size);
            Vector3 end = GetBoxCorner(lineEnd[i]);
            end.Scale(size);

            Handles.DrawLine(parent.TransformPoint(position + start), parent.TransformPoint(position + end));
        }
    }

    public static void DrawCuboid(Vector3 position, Vector3 size)
    {
        for (int i = 0; i < 12; i++)
        {
            Vector3 start = GetBoxCorner(lineStart[i]);
            start.Scale(size);
            Vector3 end = GetBoxCorner(lineEnd[i]);
            end.Scale(size);

            Handles.DrawLine(position + start, position + end);
        }
    }
    
    [MenuItem("Custom/Insert Gameobject as parent")]
    public static void InsertObject()
    {
        GameObject src = Selection.activeGameObject;
        if (src != null && AssetDatabase.GetAssetPath(src) != null)
        {
            GameObject go = new GameObject();
            go.transform.parent = src.transform.parent;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = src.transform.localPosition;
            go.transform.localRotation = Quaternion.identity;
            go.name = src.name + "_Root";
            src.transform.parent = go.transform;
        }
    }
}
