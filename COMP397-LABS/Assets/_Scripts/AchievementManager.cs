using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum AchievementType
{
  SirJumpALot, SirDiesALot,
}

public class AchievementManager : MonoBehaviour, IObserver
{
  [SerializeField] private int _currentJumps = 0;
  [SerializeField] private int _jumpsThreshold = 5;
  [SerializeField] private int _currentDeaths = 0;
  [SerializeField] private int _deathsThreshold = 2;
  [SerializeField] private PlayerController _playerSubject;

  void Awake()
  {
    _playerSubject = 
      GameObject.FindGameObjectWithTag("Player").
        GetComponent<PlayerController>();
  }
  void OnEnable() => _playerSubject.AddObserver(this);
  void OnDisable() => _playerSubject.RemoveObserver(this);
  
  public void OnNotify(PlayerEnums playerEnums)
  {
    switch (playerEnums)
    {
      case PlayerEnums.Jump:
        if (_currentJumps < _jumpsThreshold) PlayerJumped();
        break;
      case PlayerEnums.Died:
        if (_currentDeaths < _deathsThreshold) PlayerDied();
        break;
      default:
        break;
    }
  }
  private void PlayerJumped()
  {
    _currentJumps++;
    if (_currentJumps >= _jumpsThreshold)
    {
      Debug.Log($"Achievement acquired. SirJumpALot!");
      AnimateAchievement(AchievementType.SirJumpALot);
    }
  }
  
  private void AnimateAchievement(AchievementType achievementType)
  {
    Debug.Log($"{achievementType}");
  }

  private void PlayerDied()
  {
    _currentDeaths++;
    if (_currentDeaths >= _deathsThreshold)
    {
      Debug.Log($"Achievement acquired. SirDiesALot!");
      AnimateAchievement(AchievementType.SirDiesALot);
    }
  }
}
