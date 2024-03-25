using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
  [SerializeField] private int _width = 4;
  [SerializeField] private int _depth = 4;
  [SerializeField] private float _scale = 20.0f;
  [SerializeField] private GameObject _tilePrefab;
  [SerializeField] private List<Material> _tileMaterials;
  [SerializeField] private float _offsetX;
  [SerializeField] private float _offsetY;

  private GameObject[,] _map;
  private Dictionary<string, AbstractLocationFactory> _locationFactories = 
    new Dictionary<string, AbstractLocationFactory>();

  private void Start()
  {
    //GenerateRandomMap();
    _map = new GameObject[_width, _depth];
    _offsetX = Random.Range(1000, 5000);
    _offsetY = Random.Range(-5000, -1000);
    _locationFactories["Grass"] = new FactoryGrass();
    GeneratePerlinMap();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      ChangeAllMaterials();
    }
  }
  private void ChangeAllMaterials()
  {
    _offsetX = Random.Range(1000, 5000);
    _offsetY = Random.Range(-5000, -1000);
    for (int x = 0; x < _width; x++)
    {
      for (int z = 0; z < _depth; z++)
      {
        float randomMaterial = GeneratePerlinNoiseValue(x, z);
        ChangePerlinMaterial(_map[x,z], randomMaterial);
      }
    }
  }
  private void GenerateRandomMap()
  {
    for (int x = 0; x < _width; x++)
    {
      for (int z = 0; z < _depth; z++)
      {
        var go = Instantiate(_tilePrefab, new Vector3(x * 10, 0, z * 10), Quaternion.identity);
        int randomMaterial = Random.Range(0, _tileMaterials.Count);
        ChangeMaterial(go, randomMaterial);
      }
    }
  }
  private float GeneratePerlinNoiseValue(float x, float z)
  {
    float xCoord = (x + _offsetX) / _width * _scale;
    float zCoord = (z + _offsetY) / _depth * _scale;
    return Mathf.Clamp01(Mathf.PerlinNoise(xCoord,zCoord));
  }
  private void ChangeMaterial(GameObject go, int index)
  {
    go.GetComponent<Renderer>().material = _tileMaterials[index];
  }

  private void GeneratePerlinMap()
  {
    for (int x = 0; x < _width; x++)
    {
      for (int z = 0; z < _depth; z++)
      {
        _map[x,z] = Instantiate(_tilePrefab, new Vector3(x * 10, 0, z * 10), Quaternion.identity);
        float randomMaterial = GeneratePerlinNoiseValue(x, z);
        ChangePerlinMaterial(_map[x,z], randomMaterial);
      }
    }
  }
  private void ChangePerlinMaterial(GameObject go, float random)
  {
    Material material = null;
    switch (random)
    {
      case <= 0.25f:
        material = _tileMaterials[0];
        go.name += " Lava";
        break;
      case <= 0.5f:
        material = _tileMaterials[1];
        go.name += " City";
        break;
      case <= 0.75f:
        material = _tileMaterials[2];
        _locationFactories["Grass"].CreateLocation();
        go.name += " Grass";
        break;
      default:
        material = _tileMaterials[3];
        go.name += " Water";
        break;
    }
    go.GetComponent<Renderer>().material = material;
  }
}