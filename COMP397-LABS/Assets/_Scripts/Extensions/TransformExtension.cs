using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension
{
  public static IEnumerable<Transform> Children(this Transform parent)
  {
    foreach (Transform child in parent)
    {
      yield return child;
    }
  }

  private static void ForEveryChildDo(this Transform parent, System.Action<Transform> action)
  {
    for (int i = parent.childCount - 1; i >= 0; i--)
    { 
      action(parent.GetChild(i));
    }
  }
  
  public static void DestroyChildren(this Transform parent)
  {
    parent.ForEveryChildDo(child => Object.Destroy(child.gameObject));
  }
  
  public static void DisableChildren(this Transform parent)
  {
    parent.ForEveryChildDo(child => child.gameObject.SetActive(false));
  }
  
  public static void EnableChildren(this Transform parent)
  {
    parent.ForEveryChildDo(child => child.gameObject.SetActive(true));
  }

  public static void RenameChildren(this Transform parent)
  {
    parent.ForEveryChildDo(child => child.gameObject.name = $"Child #{child.GetSiblingIndex()}");
  }
}
