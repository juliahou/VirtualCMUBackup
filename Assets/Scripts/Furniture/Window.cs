using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Selectable
{
  public override void Action() {
    StartCoroutine(CheckWeather());
  }

  public IEnumerator CheckWeather() {
    dialogue.caller = this;
    string[] options;
    switch(Global.Instance.Weather()) {
      case "Rain":
        options = new string[] { "It's raining.", "Looks like rain.", "Rain..." };
        break;
      case "Sunny":
        options = new string[] { "Looks like nice weather.", "It's sunny outside.", "The sun is shining!" };
        break;
      case "Clear":
        options = new string[] { "The sky is clear." };
        break;
      case "Cloudy":
        options = new string[] { "The weather is mild.", "Partly cloudy." };
        break;
      default:
        options = new string[] { "I'm not sure." };
        break;
    }
    string msg = options[Random.Range(0, options.Length)];
    yield return dialogue.Speech(msg, "Window");
    dialogue.Clear();
    yield return null;
  }
}
