using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    protected MeshRenderer _renderer;
    protected MeshFilter _filter;

    protected Vector3[] _vertices;
    protected int[] _triangles;
    protected Vector2[] _uv;
    protected Vector3[] _normals;

    protected Mesh _mesh;

    private void Awake()
    {
        _renderer = this.GetComponent<MeshRenderer>();
        _filter = this.GetComponent<MeshFilter>();

        _renderer.material = new Material(Shader.Find("Standard"));
        _renderer.material.SetTexture("_MainTex", Resources.Load<Texture2D>("Images/checker"));
    }

    protected virtual void Start()
    {
        GenerateMesh(_vertices, _triangles, _uv, _normals);
    }

    void GenerateMesh(Vector3[] newVertices, int[] newTriangles, Vector2[] newUv, Vector3[] newNormals)
    {
        _mesh = new Mesh()
        {
            vertices = newVertices,
            triangles = newTriangles,
            uv = newUv,
            normals = newNormals
        };

        _filter.mesh = _mesh;
    }
}
