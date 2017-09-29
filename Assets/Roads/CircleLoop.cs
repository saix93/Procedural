using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shape
{
    public float Radius         { get; private set; }
    public float LongStep       { get; private set; }
    public int CircleSteps      { get; private set; }
    public int Steps            { get; private set; }
    public Vector2 SizeSquare   { get; private set; }

    public Shape(float radius, int circleSteps, int steps, float longStep, Vector2 sizeSquare)
    {
        this.Radius = radius;
        this.LongStep = longStep;
        this.CircleSteps = circleSteps;
        this.Steps = steps;
        this.SizeSquare = sizeSquare;
    }
}

public class CircleLoop
{
    public void GenerateShape(Shape infoShape, out Mesh mesh, out Dictionary<Vector3, Vector3> directions)
    {
        var vertices = GenerateVertex(infoShape);

        mesh = GenerateMesh(vertices[0]);
        directions = vertices[1];
    }

    /// <returns>0-index: vertices del mesh 1-index: direcciones</returns>
    Dictionary<Vector3, Vector3>[] GenerateVertex(Shape infoShape)
    {
        var vertexDic = new Dictionary<Vector3, Vector3>();
        var directionDic = new Dictionary<Vector3, Vector3>();

        float increment = 360.0f / infoShape.CircleSteps;

        for(int s = 0; s < infoShape.Steps; s++)
        {
            for(int i = 0; i < infoShape.CircleSteps; i++)
            {
                //angulo actual del circulo (este paso)
                float angle = (increment * (i + 1));

                //indice de este array (en 1 dimension)
                int index = s * infoShape.CircleSteps + i;

                //Posicion central del circulo respecto a la posicion de este quad
                Vector3 centerPosition = new Vector3()
                {
                    x = 0,
                    y = 0,
                    z = infoShape.LongStep * index
                };

                //Posicion central del quad que se va a crear
                Vector3 centerQuad = GetPosition(angle, index, infoShape);

                //Posicion del siguiente quad para cualcular las direcciones
                Vector3 posNext = GetPosition((increment * (i + 2)), index+1, infoShape);

                //Calculamos la direccion "right" (fwd lo calculamos sacando la direccion del "siguiente" circulo)
                //"up", si miramos desde cada quad individual hacia el centro del circulo y "right" por cross product
                Vector3 fwdDirection = (centerPosition - centerQuad).normalized;
                Vector3 upDirection = (posNext - centerQuad).normalized;
                Vector3 rightDirection = Vector3.Cross(upDirection, fwdDirection).normalized;

                Vector3 rightVertex = ((centerQuad + rightDirection * infoShape.SizeSquare.x) + upDirection * infoShape.SizeSquare.y);
                Vector3 leftVertex = ((centerQuad - rightDirection * infoShape.SizeSquare.x) + upDirection * infoShape.SizeSquare.y);

                vertexDic.Add(rightVertex, fwdDirection);
                vertexDic.Add(leftVertex, fwdDirection);

                directionDic.Add(centerQuad, (posNext - centerQuad).normalized);
            }
        }

        return new[] { vertexDic, directionDic };
    }

    Mesh GenerateMesh(Dictionary<Vector3, Vector3> vertices)
    {
        Mesh mesh = new Mesh();

        var meshVertices = new Vector3[vertices.Count];
        var meshNormals = new Vector3[vertices.Count];
        var meshTriangles = new List<int>();
        var meshUVS = new List<Vector2>();

        for(int i = 0; i < vertices.Count; i++)
        {
            meshVertices[i] = vertices.Keys.ElementAt(i);
            meshNormals[i] = vertices.Values.ElementAt(i);
        }

        for(int i = 0; i < vertices.Count; i++)
        {
            var value = 2 * i;
            if (value + 3 > vertices.Count - 1) continue;

            meshTriangles.Add(value + 2);
            meshTriangles.Add(value + 1);
            meshTriangles.Add(value + 0);

            meshTriangles.Add(value + 2);
            meshTriangles.Add(value + 3);
            meshTriangles.Add(value + 1);
        }

        for(int i = 0; i < vertices.Count/4; i++)
        {
            meshUVS.Add(new Vector2(1, 0));
            meshUVS.Add(new Vector2(0, 0));
            meshUVS.Add(new Vector2(1, 1));
            meshUVS.Add(new Vector2(0, 1));
        }

        mesh.vertices = meshVertices;
        mesh.normals = meshNormals;
        mesh.triangles = meshTriangles.ToArray();
        mesh.uv = meshUVS.ToArray();

        return mesh;
    }


    Vector3 GetPosition(float angle, int step, Shape infoShape)
    {
        return new Vector3()
        {
            x = Mathf.Cos(angle * Mathf.Deg2Rad) * infoShape.Radius,
            y = Mathf.Sin(angle * Mathf.Deg2Rad) * infoShape.Radius,
            z = infoShape.LongStep * step
        };
    }
}

