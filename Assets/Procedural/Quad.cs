using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MeshGenerator
{
    [SerializeField][Range(.1f, 10f)] float _width;
    [SerializeField][Range(.1f, 10f)] float _height;

    protected override void Start()
    {
        _vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, _height, 0),
            new Vector3(_width, 0, 0),
            new Vector3(_width, _height, 0)
        };

        _triangles = new int[]
        {
            0,1,2,
            2,1,3
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
            -Vector3.forward,
            -Vector3.forward
        };

        base.Start();

        _mesh.MarkDynamic();
    }

    protected virtual void Update()
    {
        _vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, _height, 0),
            new Vector3(_width, 0, 0),
            new Vector3(_width, _height, 0)
        };

        base.Start();
    }
}
