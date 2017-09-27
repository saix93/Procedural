using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MeshGenerator
{
    protected override void Start()
    {
        _vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 1, 1)
        };

        _triangles = new int[]
        {
            0,1,2,
            2,1,3,

            1,5,3,
            3,5,7,

            2,3,6,
            6,3,7,

            4,5,0,
            0,5,1,

            4,0,6,
            6,0,2,

            6,7,4,
            4,7,5
        };

        _uv = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,0),
            new Vector2(1,1)
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
