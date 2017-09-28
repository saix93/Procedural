using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Triangle : MonoBehaviour
{
    protected MeshRenderer _renderer;
    protected MeshFilter _filter;

    protected Mesh _mesh;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _filter = GetComponent<MeshFilter>();

        _renderer.material = new Material(Shader.Find("Standard"));
        _renderer.material.SetTexture("_MainTex", Resources.Load<Texture2D>("Images/checker"));

        _mesh = new Mesh();
        Generate(ref _mesh);
        _filter.mesh = _mesh;
    }

    protected virtual void Generate(ref Mesh mesh)
    {
        mesh.vertices = new Vector3[]
        {
            new Vector3(0,0),
            new Vector3(0,1),
            new Vector3(1,0)
        };

        mesh.triangles = new int[]
        {
            0,1,2
        };

        mesh.uv = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,0)
        };

        mesh.normals = new Vector3[]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };

    }
}
