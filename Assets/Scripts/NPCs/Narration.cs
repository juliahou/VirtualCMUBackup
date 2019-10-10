using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : NPC
{


  public override void Action() {
    StartCoroutine("InitialDialogue");
  }

  public IEnumerator InitialDialogue() {
    dialogue.caller = this;
    yield return dialogue.Speech("Welcome to MoVRewood, " + pldata.name + "! Please try to keep the kitchen and the common areas clean!");
    yield return dialogue.Speech("Also, we will be having an event at 5pm on Friday for everyone in the dorm. Come join us and have some fun!");
    dialogue.Clear();
    yield return null;
  }
}
