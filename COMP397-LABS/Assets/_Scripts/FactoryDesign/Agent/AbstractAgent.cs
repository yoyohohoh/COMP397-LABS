
using UnityEngine;
using UnityEngine.AI;

public abstract class AbstractAgent : MonoBehaviour, IAgent
{
  public NavMeshAgent _myself;
  public Vector3 _destination;
  public bool _isJobCompleted;
  public abstract void Navigate(Transform destination);
  public abstract void CompleteJob();
}
