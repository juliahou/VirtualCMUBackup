using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : Selectable
{


  public override void Action() {
    StartCoroutine("TimeInterface");
  }

  public IEnumerator TimeInterface() {
    dialogue.caller = this;
    yield return dialogue.Menu("Choose Function", new string[] { "Restart Day", "Adjust Speed" });
    switch(response) {
      case "Restart Day":
        StartCoroutine("Load");
        break;
      case "Adjust Speed":
        StartCoroutine("AdjustSpeed");
        break;
    }
  }

  IEnumerator AdjustSpeed() {
    yield return dialogue.Menu("Choose Function", new string[] { "Hyper fast", "Fast", "Slow", "Hyper slow", "RESET" });
    switch(response) {
      case "Hyper fast":
        Time.timeScale = 16.0f;
        break;
      case "Fast":
        Time.timeScale = 4.0f;
        break;
      case "Slow":
        Time.timeScale = 0.25f;
        break;
      case "Hyper slow":
        Time.timeScale = 0.0625f;
        break;
      case "RESET":
        Time.timeScale = 1.0f;
        break;
    }
    dialogue.Clear();
    yield return null;
  }
  IEnumerator Load() {
    Time.timeScale = 1.0f;
    Global.Instance.StartCoroutine("RestartDay");
    dialogue.Clear();
    yield return null;
  }
}
