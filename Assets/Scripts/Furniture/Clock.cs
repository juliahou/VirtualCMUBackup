using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : Selectable
{
  public Text timeText;
  new void Update()
  {
    timeText.text = Global.Instance.hour + (Global.Instance.minute < 10 ? ":0" : ":") + Global.Instance.minute;
    base.Update();
  }
  public override void Action() {
    StartCoroutine(TimeCheck());
  }

  public IEnumerator TimeCheck() {
    dialogue.caller = this;
    yield return dialogue.Speech("It's " + timeText.text);
    dialogue.Clear();
    yield return null;
  }
}
