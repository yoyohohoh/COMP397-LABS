using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncProgram : MonoBehaviour
{
    private CancellationTokenSource _cancellationToken;
    private void Start()
    {
        StartCoroutine(DebugMyCoroutineMessage());
        DebugMyTaskMessage();
        Destroy(gameObject, 1.5f);
    }

    private void OnDestroy()
    {
        StopCoroutine(DebugMyCoroutineMessage());
        _cancellationToken?.Cancel();
    }
    private async void DebugMyTaskMessage()
    {
        _cancellationToken = new CancellationTokenSource();
        Debug.Log($"Async Method Started");
        await Task.Delay(5000, _cancellationToken.Token);
        Debug.Log(($"Async Method Completed"));
    }
    private IEnumerator DebugMyCoroutineMessage()
    {
        Debug.Log($"Coroutine Method Started");
        yield return new WaitForSecondsRealtime(5f);
        Debug.Log(($"Coroutine Method Completed"));
    }
}
