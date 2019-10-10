using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : Selectable
{
  public override void Action() {
    StartCoroutine("HomeworkDialogue");
  }

  public IEnumerator HomeworkDialogue() {
    dialogue.caller = this;
    yield return dialogue.Speech("You don't have any homework yet!", "Desk");
    dialogue.Clear();
    yield return null;
  }
}
