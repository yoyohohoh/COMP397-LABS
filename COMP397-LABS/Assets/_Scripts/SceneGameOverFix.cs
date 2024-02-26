using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneGameOverFix : MonoBehaviour
{
    [SerializeField] private Button _menuBtn;
    [SerializeField] private string _menuSceneName;
    void Start()
    {
        _menuBtn.onClick.AddListener(() =>
        {
            SceneController.Instance.ChangeSceneByName(_menuSceneName);
        });
    }
}