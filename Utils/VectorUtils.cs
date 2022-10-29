using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class VectorUtils
{
    public static float DistanceToLine(Ray ray, Vector3 point) { return Vector3.Cross(ray.direction, point - ray.origin).magnitude; }

    public static float DistanceToLineSqr(Ray ray, Vector3 point) { return Vector3.Cross(ray.direction, point - ray.origin).sqrMagnitude; }
   
    public static Vector3 GetRayPointAtHeight(Ray ray, float height = 0)
    {
        return ray.origin - (ray.origin.y - height) / ray.direction.y * ray.direction;
    }

    public static Vector3 GetRayPointAtFront(Ray ray, float front = 0)
    {
        return ray.origin - (ray.origin.z - front) / ray.direction.z * ray.direction;
    }

    public static float DistanceToSegment(Vector3 point, Vector3 seg_start, Vector3 seg_end, out float proj)
    {
        // Return minimum distance between line segment vw and point p
        float l2 = (seg_end - seg_start).sqrMagnitude;  // i.e. |w-v|^2 -  avoid a sqrt
        if (l2 == 0.0)
        {
            proj = 0;
            return (point - seg_start).magnitude;   // v == w case
        }
        // Consider the line extending the segment, parameterized as v + t (w - v).
        // We find projection of point p onto the line. 
        // It falls where t = [(p-v) . (w-v)] / |w-v|^2
        float t = Vector3.Dot(point - seg_start, seg_end - seg_start) / l2;
        if (t < 0.0)
        {
            proj = 0;
            return Vector3.Distance(point, seg_start);       // Beyond the 'v' end of the segment
        }
        else if (t > 1.0)
        {
            proj = 1;
            return Vector3.Distance(point, seg_end);  // Beyond the 'w' end of the segment
        }
        Vector3 projection = seg_start + t * (seg_end - seg_start);  // Projection falls on the segment
        proj = t;
        return Vector3.Distance(point, projection);
    }

    public static Vector3 GetRaycastOrPointAtHeight(Ray ray)
    {
        RaycastHit hit;
        Vector3 point = Vector3.zero;
        if (Physics.Raycast(ray, out hit))
            point = hit.point;
        else
            point = VectorUtils.GetRayPointAtHeight(ray);
        return point;
    }

    public static int GetNearestPoint(List<Vector3> points, Ray r, float measure = 0.5f, Transform transform = null)
    {
        int to_del = -1;
        for (int i = 0; i < points.Count; i++)
        {
            if (DistanceToLine(r, transform ? transform.TransformPoint(points[i]) : points[i]) < measure)
            {
                to_del = i;
            }
        }
        return to_del;
    }

    public static bool IsPointNearEdge(Vector3 point, Vector3 p1, Vector3 p2, float measure = 0.5f)
    {
        Ray r = new Ray(p1, (p2 - p1).normalized);
        if (DistanceToLine(r, point) < measure)
        {
            if (Vector3.Dot(point - p1, p2 - p1) > 0 &&
                Vector3.Dot(point - p2, p1 - p2) > 0)
            {
                return true;
            }
        }
        return false;
    }
}
