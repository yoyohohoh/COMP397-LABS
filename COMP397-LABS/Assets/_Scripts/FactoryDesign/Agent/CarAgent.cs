using UnityEngine;

public class CarAgent : AbstractAgent, IAgent
{
  private void FixedUpdate()
  {
    if (_isJobCompleted || !(Vector3.Distance(transform.position, _destination) < 1.5f))
    { return; }
    
    _isJobCompleted = true;
    CompleteJob();
  }
  public override void Navigate(Transform location)
  {
    _destination = location.position;
    _myself.destination = _destination;
  }
  public override void CompleteJob()
  {
    Debug.Log($"Job Completed");
    Destroy(gameObject, 1.5f);
  }
}
