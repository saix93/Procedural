using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class CirclePlayer : MonoBehaviour
{
    [SerializeField] float _forceForward;
    [SerializeField] float _forceMovement;

    Rigidbody _rb;
    GameObject _sphereTarget;

    Vector3 _direction;
    TrackGenerator.CircleData _actualCircleData;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _sphereTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _sphereTarget.transform.localScale = Vector3.one * .75f;
        _sphereTarget.GetComponent<MeshRenderer>().sharedMaterial.color = Color.yellow;
        Destroy(_sphereTarget.GetComponent<Collider>());
    }

    private void OnCollisionStay(Collision collision)
    {
        TrackGenerator.CircleData circleData = collision.collider.GetComponent<TrackGenerator.CircleData>();

        if (circleData)
        {
            var playerRelativeCirclePosition = collision.transform.InverseTransformPoint(this.transform.position);
            int indexDistance = 0;
            int i = 0;
            float minDistance = float.MaxValue;

            foreach (var v in circleData.Directions)
            {
                var dis = Vector3.Distance(playerRelativeCirclePosition, v.Key);

                if (dis < minDistance)
                {
                    minDistance = dis;
                    indexDistance = i;
                }

                i++;
            }

            var dir = circleData.Directions.Values.ElementAt(indexDistance);
            _direction = dir.normalized;
            _sphereTarget.transform.position = collision.transform.TransformPoint(circleData.Directions.Keys.ElementAt(indexDistance));
        }

        _rb.AddForce(_direction * _forceMovement, ForceMode.Force);
    }
}
