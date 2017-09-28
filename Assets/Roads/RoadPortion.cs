using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPortion
{
    /// <summary>
    /// La forma que va a tener este trozo de geometría
    /// </summary>
    public enum EShape
    {
        Line,
        RightCurve,
        LeftCurve
    }

    readonly float WIDTH_ROAD;
    readonly float LONG_ROAD;
    readonly int SUBDIVISION_CURVE;
    readonly int SUBDIVISION_LINE;

    public RoadPortion(float widthRoad, float longRoad, int subdivisionCurve, int subdivisionLine)
    {
        WIDTH_ROAD = widthRoad;
        LONG_ROAD = longRoad;
        SUBDIVISION_CURVE = subdivisionCurve;
        SUBDIVISION_LINE = subdivisionLine;
    }

    Mesh GetMesh(EShape shape)
    {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<Vector3> normals = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
        List<int> triangles = new List<int>();

        mesh.SetVertices(vertices);
        mesh.triangles = triangles.ToArray();
        mesh.normals = normals.ToArray();
        mesh.uv = uvs.ToArray();

        return mesh;
    }

    void GenerateLine(List<Vector3> vertices, List<Vector3> normals, List<Vector2> uvs, List<int> triangles)
    {

    }

    void GenerateCurve(int direction, List<Vector3> vertices, List<Vector3> normals, List<Vector2> uvs, List<int> triangles)
    {

    }
}
