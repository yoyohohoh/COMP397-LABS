using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConcreteFactory : MonoBehaviour
{
  [SerializeField] private List<AbstractFactory> _transportFactories;
  private AbstractFactory _factory;

  private void Start()
  {
    _factory = _transportFactories[0];
  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      StartCoroutine(GenerateAgents());
    }
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      StopCoroutine(GenerateAgents());
    }
  }

  private IEnumerator GenerateAgents()
  {
    var time = new WaitForSeconds(_factory.SpawnTimer);
    while (true)
    {
      _factory.CreateAgent();
      _factory = _transportFactories[Random.Range(0, _transportFactories.Count)];
      yield return time;
    } 
  }
}
