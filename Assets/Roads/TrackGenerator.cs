﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public class CircleData : MonoBehaviour
    {
        public Dictionary<Vector3, Vector3> Directions;

        private void OnDrawGizmos()
        {
            foreach (var c in Directions)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(c.Key + this.transform.position, c.Value * 2);

                Gizmos.color = Color.blue;
                Gizmos.DrawCube(c.Key + this.transform.position, Vector3.one * .5f);
            }
        }
    }

    [SerializeField] float _radius;
    [SerializeField] float LongStep;
    [SerializeField] int _steps;
    [SerializeField] int _circleSteps;
    [SerializeField] Vector2 _sizeSquad;

    [SerializeField] Material _materialToApply;
    Material _material;

    CircleLoop _circleLoop;
    Dictionary<Vector3, Vector3> data;

    void Start()
    {
        _material = new Material(_materialToApply);

        _circleLoop = new CircleLoop();

        GameObject go = new GameObject("Base");

        Mesh mesh = null;
        Shape shape = new Shape(_radius, _circleSteps, _steps, LongStep, _sizeSquad);
        _circleLoop.GenerateShape(shape, out mesh, out data);

        go.AddComponent<MeshFilter>().mesh = mesh;
        go.AddComponent<MeshCollider>().sharedMesh = mesh;
        go.AddComponent<MeshRenderer>().material = _material;
        go.AddComponent<CircleData>().Directions = data;
        //... apply direction
    }

   
}
