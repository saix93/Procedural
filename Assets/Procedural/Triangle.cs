using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MeshGenerator
{
    protected override void Start()
    {
        _vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0)
        };

        _triangles = new int[]
        {
            0,1,2
        };

        _uv = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,0)
        };

        _normals = new Vector3[]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };

        base.Start();
    }
}
