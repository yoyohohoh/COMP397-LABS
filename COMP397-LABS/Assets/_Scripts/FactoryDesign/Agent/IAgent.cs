using UnityEngine;

public interface IAgent
{
  void Navigate(Transform destination);
  void CompleteJob();
}
