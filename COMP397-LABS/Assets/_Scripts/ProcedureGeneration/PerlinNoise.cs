using System;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    [SerializeField]
    private int _width = 256;
    [SerializeField] private int _height = 256;
    [SerializeField] private float _scale = 20.0f;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _renderer.material.mainTexture = GenerateTexture();
    }

    private Texture2D GenerateTexture()
    {
        var texture = new Texture2D(_width, _height);
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                Color color = CalculateColor(i, j);
                texture.SetPixel(i, j, color);
            }
        }
        texture.Apply();
        return texture;
    }

    private Color CalculateColor(int x, int y)
    {
        float coordX = (float)x / _width * _scale;
        float coordY = (float)y / _height * _scale;
        float sample = Mathf.PerlinNoise(coordX, coordY);
        return new Color(sample, sample, sample);
    }
}