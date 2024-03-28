using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public interface IJokeTeller
{
  public void TellJoke();
}
public abstract class JokeFactory
{
  public abstract IJokeTeller CreateJoke();
}

public class ComedianBehaviour : MonoBehaviour
{
  /// <summary>
  /// After factory method
  /// </summary>
  public List<JokeFactory> jokeFactories;
  private JokeFactory _jokeFactory;

  public void DeliverFactoryJoke()
  {
    _jokeFactory = jokeFactories[Random.Range(0, jokeFactories.Count)];
    IJokeTeller jokeTeller = _jokeFactory.CreateJoke();
    jokeTeller.TellJoke();
  }
  
  
  /// <summary>
  /// Before Factory Method Design
  /// </summary>
  [SerializeField] private TextMeshProUGUI _comedianTMP;
  public List<GameObject> whyDidSomethingJokes;
  public List<GameObject> barJokes;
  public List<GameObject> sportJokes;
  public JokeType jokeTypeToTell;

  public void DeliverJoke()
  {
    CreateJokeBasedOnType(jokeTypeToTell);
  }

  private void CreateJokeBasedOnType(JokeType jokeType)
  {
    List<GameObject> selected = null;
    switch (jokeType)
    {
      case JokeType.Something:
        selected = whyDidSomethingJokes;
        break;
      case JokeType.Bar:
        selected = barJokes;
        break;
      case JokeType.Sports:
        selected = sportJokes;
        break;
    }
  }
}
public enum JokeType
{
  Something, Bar, Sports,
}