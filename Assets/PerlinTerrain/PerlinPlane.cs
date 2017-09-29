using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinPlane : MonoBehaviour
{
    [SerializeField] float _scale;
    [SerializeField] float _power;

    void Update()
    {
        MakePerlin();
    }

    void MakePerlin()
    {
        var mesh = GetComponent<MeshFilter>().sharedMesh;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            float x = Time.time + vertices[i].x * _scale;
            float y = Time.time + vertices[i].y * _scale;

            vertices[i].y = Mathf.PerlinNoise(x, y) * _power;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }
}
