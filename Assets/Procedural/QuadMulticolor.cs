using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMulticolor : Quad
{
    [SerializeField]
    EColors _currentColor;

    enum EColors
    {
        All,
        Red,
        Green,
        Blue,
        Yellow
    }

    protected override void Start()
    {
        _renderer.material.SetTexture("_MainTex", Resources.Load<Texture2D>("Images/multicolor"));

        base.Start();
    }

    protected override void Update()
    {
        ChangeColor();
        base.Update();
    }

    void ChangeColor()
    {
        switch (_currentColor)
        {
            case EColors.All:
                _uv = new Vector2[]
                {
                    new Vector2(0,0),
                    new Vector2(0,1),
                    new Vector2(1,0),
                    new Vector2(1,1)
                };
                break;

            case EColors.Red:
                _uv = new Vector2[]
                {
                    new Vector2(0,.5f),
                    new Vector2(0,1),
                    new Vector2(.5f,.5f),
                    new Vector2(.5f,1)
                };
                break;

            case EColors.Green:
                _uv = new Vector2[]
                {
                    new Vector2(0,0),
                    new Vector2(0,.5f),
                    new Vector2(.5f,0),
                    new Vector2(.5f,.5f)
                };
                break;

            case EColors.Blue:
                _uv = new Vector2[]
                {
                    new Vector2(.5f,.5f),
                    new Vector2(.5f,1),
                    new Vector2(1,.5f),
                    new Vector2(1,1)
                };
                break;

            case EColors.Yellow:
                _uv = new Vector2[]
                {
                    new Vector2(.5f,0),
                    new Vector2(.5f,.5f),
                    new Vector2(1,0),
                    new Vector2(1,.5f)
                };
                break;

            default:
                break;
        }
    }
}
