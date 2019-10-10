using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rony : NPC
{
  public override void Action() {
    StartCoroutine("DefaultDialogue");
  }

  public IEnumerator DefaultDialogue() {
    dialogue.caller = this;
    yield return dialogue.Speech("Hello!");
    yield return dialogue.Menu("What's up?", new string[] { "Nothing", "Something" });
    switch(response) {
      case "Nothing":
        break;
      default:
        break;
    }
    dialogue.Clear();
    yield return null;
  }
}
