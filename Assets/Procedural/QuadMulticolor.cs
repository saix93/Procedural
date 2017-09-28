using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMulticolor : Quad
{
    [SerializeField]EColors _currentColor;
    enum EColors
    {
        All,
        Red,
        Blue,
        Green,
        Yellow
    }

    protected override void Update()
    {
        _renderer.material.SetTexture("_MainTex", Resources.Load<Texture2D>("Images/multicolor"));

        _mesh.vertices = new Vector3[]
        {
            new Vector3(0,0),
            new Vector3(0,_height),
            new Vector3(_width,0),
            new Vector3(_width,_height)
        };

        ChangeColor();
    }

    void ChangeColor()
    {
        switch (_currentColor)
        {
            case EColors.All:
                _mesh.uv = new Vector2[]
                {
                    new Vector2(0,0),
                    new Vector2(0,1f),
                    new Vector2(1f,0),
                    new Vector2(1f,1f)
                };
                break;

            case EColors.Red:
                _mesh.uv = new Vector2[]
                {
                    new Vector2(.0f,.5f),
                    new Vector2(.0f,1f),
                    new Vector2(.5f,.5f),
                    new Vector2(.5f,1f)
                };
                break;

            case EColors.Blue:
                _mesh.uv = new Vector2[]
                {
                    new Vector2(.0f,.0f),
                    new Vector2(.0f,.5f),
                    new Vector2(.5f,.0f),
                    new Vector2(.5f,.5f)
                };
                break;

            case EColors.Green:
                _mesh.uv = new Vector2[]
                {
                    new Vector2(.5f,.5f),
                    new Vector2(.5f,1f),
                    new Vector2(1f,.5f),
                    new Vector2(1f,1f)
                };
                break;

            case EColors.Yellow:
                _mesh.uv = new Vector2[]
                {
                    new Vector2(0.5f,0.0f),
                    new Vector2(.5f,.5f),
                    new Vector2(1f,0f),
                    new Vector2(1f,.5f)
                };
                break;

            default:break;
        }

    }
}
