using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Examples : MonoBehaviour
{
  [SerializeField] private GameObject _prefab;

  private void Start()
  {
    InstantiateViaAsync();
  }
  private async void InstaTask()
  {
    await Task.Run(InstantiateViaAsync);
  }
  private async void InstantiateViaAsync()
  {
    Debug.Log($"Insta Via Async");
    GameObject go = Instantiate(_prefab, new Vector3(0,0,0), Quaternion.identity);
    await Task.Delay(3000);
    Debug.Log($"Insta Via Async ended");
    go.transform.SetParent(transform);
  }

  private void CallTransformExample()
  {
    GameObject go = Instantiate(_prefab, transform.position, Quaternion.identity);
    Vector3 newPos = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
    go.transform.position = newPos;
    go.transform.SetParent(transform);

    GameObject go2 = Instantiate(_prefab, transform.position.With(x: -3f), Quaternion.identity);
    go2.transform.SetParent(transform);

    CallTransformExtensions();
  }

  private async void CallTransformExtensions()
  {
    // for (int i = 0; i < transform.childCount; i++)
    // {
    //   var child = transform.GetChild(i);
    //   Debug.Log($"Child name {child.name}");
    // }
    //
    // foreach (Transform child in transform.Children())
    // {
    //   Debug.Log($"Child name {child.name}");
    // }
    await Task.Run(ExecuteTransformsTasks);
    StartCoroutine(ExecuteTransformsExtensions());
  }
  private IEnumerator ExecuteTransformsExtensions()
  {
    Debug.Log($"Coroutine Start");
    yield return new WaitForSeconds(1.5f);
    Debug.Log($"Coroutine Disable Children");
    transform.DisableChildren();
    yield return new WaitForSeconds(1.5f);
    Debug.Log($"Coroutine Enable Children");
    transform.EnableChildren();
    yield return new WaitForSeconds(1.5f);
    Debug.Log($"Coroutine Destroy");
    transform.DestroyChildren();
  }

  private async Task ExecuteTransformsTasks()
  {
    Debug.Log($"Task Call Start");
    await Task.Delay(500);
    var component = gameObject.GetComponent<Examples>();
    transform.RenameChildren();
  }
}
