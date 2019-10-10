using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Selectable
{
  public override void Action() {
    if(Global.Instance.TimeOfDay() == "Night") {
      StartCoroutine(SleepDialogue());
    }
    else if(Global.Instance.TimeOfDay() == "Late Night") {
      StartCoroutine(SleepDialogue());
    }
    else {
      StartCoroutine(NoSleepDialogue());
    }
  }

  public IEnumerator NoSleepDialogue() {
    dialogue.caller = this;
    yield return dialogue.Speech("It's a little early to go to sleep");
    dialogue.Clear();
    yield return null;
  }

  public IEnumerator SleepDialogue() {
    dialogue.caller = this;
    dialogue.Speech("zzz...");
    Initiate.Fade("", Color.black, 2.0f);
    yield return new WaitForSeconds(1.0f);
    Initiate.scr.isFadeIn = true;
    dialogue.Clear();
    yield return null;
  }
}
