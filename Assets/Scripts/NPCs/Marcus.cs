using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcus : NPC
{


  public override void Action() {
    StartCoroutine("DefaultDialogue");
  }

  public IEnumerator DefaultDialogue() {
    dialogue.caller = this;
    yield return dialogue.Speech("Hi");
    StartCoroutine("SmashDialogue");
    yield return null;
  }

  public IEnumerator SmashDialogue() {
    dialogue.caller = this;

    yield return dialogue.Menu("Want to play smash?", new string[] { "Sure", "No thanks" });
    switch(response) {
      case "Sure":
        yield return dialogue.Speech("I'll meet you in the lounge.");
        break;
      default:
        break;
    }

    dialogue.Clear();
    yield return null;
  }
}
