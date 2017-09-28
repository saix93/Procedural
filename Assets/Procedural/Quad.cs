using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : Triangle
{
    [SerializeField][Range(.1f,10f)] protected float _width;
    [SerializeField][Range(.1f, 10f)] protected float _height;

    protected virtual void Update()
    {
        Generate(ref base._mesh);
    }

    private void Start()
    {
        base._mesh.MarkDynamic();
    }

    protected override void Generate(ref Mesh mesh)
    {
        mesh.vertices = new Vector3[]
        {
            new Vector3(0,0),
            new Vector3(0,_height),
            new Vector3(_width,0),
            new Vector3(_width,_height)
        };

        mesh.triangles = new int[]
        {
            0,1,2,
            2,1,3
        };

        mesh.uv = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,0),
            new Vector2(1,1)
        };

        mesh.normals = new Vector3[]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
    }
}
