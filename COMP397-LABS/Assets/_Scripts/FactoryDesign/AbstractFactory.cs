using UnityEngine;

public abstract class AbstractFactory : MonoBehaviour
{
  public float SpawnTimer;
  public GameObject AgentPrefab;
  public Transform SpawnLocation;
  public Transform AgentDestination;

  public abstract void CreateAgent();
}
