using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePoints : MonoBehaviour
{
    [SerializeField] [Range(1, 20)] int _points = 10;
    [SerializeField] [Range(1, 10)] float _interiorScale = 1;
    [SerializeField] [Range(1, 10)] float _exteriorScale = 1;
    float _increment;

    private void Start()
    {
        _increment = Mathf.PI * 2 / _points;

        for (int i = 0; i < _points + 1; i++)
        {
            float f = _increment * i;
            float x = Mathf.Sin(f);
            float y = Mathf.Cos(f);

            Vector3 interiorPosition = new Vector3(x, 0, y) * _interiorScale;
            Vector3 exteriorPosition = new Vector3(x, 0, y) * _exteriorScale;

            CreateSphere(interiorPosition, i);
            CreateSphere(exteriorPosition, i);
        }
    }

    GameObject CreateSphere(Vector3 position, int index = -1)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.localScale = Vector3.one * .1f;
        sphere.transform.position = position;

        if (index >= 0)
        {
            GameObject textGO = new GameObject("text");
            TextMesh text = textGO.AddComponent<TextMesh>();
            text.anchor = TextAnchor.MiddleCenter;
            text.text = index.ToString();
            text.color = Color.red;
            text.characterSize = .1f;

            textGO.transform.SetParent(sphere.transform);
            textGO.transform.rotation = Quaternion.Euler(90, 0, 0);
            textGO.transform.localPosition = Vector3.zero;
        }

        return sphere;
    }
}
