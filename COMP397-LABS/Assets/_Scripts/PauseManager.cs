using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pausePanel;
    private CharacterController _playerController;
    private COMP397LABS _inputs;
    void Awake()
    {
        _playerController = _player.GetComponent<CharacterController>();
        _inputs = new COMP397LABS();
        _inputs.Player.Pause.performed += context => PauseGame();
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }
    

    public void PauseGame()
    {
        _playerController.enabled = false;
        _pausePanel.SetActive(true);
    }

    public void UnpauseGame()
    {
        _playerController.enabled = true;
        _pausePanel.SetActive(false);
    }
}
