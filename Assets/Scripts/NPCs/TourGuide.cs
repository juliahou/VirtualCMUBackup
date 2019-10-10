using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourGuide : NPC
{
  public override void Action() {
    if(DLIndex == 0) {
      StartCoroutine(DefaultDialogue());
    }
    else {
      StartCoroutine(Repeat());
    }
  }

  public IEnumerator Repeat() {
    dialogue.caller = this;
    yield return dialogue.Menu("Repeat instructions?", new string[] { "Yes", "No" });
    if(response == "Yes") {
      yield return Instructions();
    }
    dialogue.Clear();
    yield return null;
  }
  public IEnumerator DefaultDialogue() {
    dialogue.caller = this;
    yield return dialogue.Speech("Let's get started. So we actually have a couple of paths for this cliff tour you guys can choose from.");
    yield return dialogue.Speech("We have this difficult one, but it’s more exciting. Or the easier one, which is safer. Here are a couple more details.");
    yield return Instructions();
    yield return dialogue.Speech("I'll let you two discuss what you guys want to do.");
    DLIndex += 1;
    GameObject.FindObjectOfType<Partner>().DLIndex += 1;
    dialogue.Clear();
    yield return null;
  }

  public IEnumerator Instructions() {
    dialogue.caller = this;
    yield return dialogue.Speech("This is a cliff walking task where you have the opportunity to pick up coins until the end. There are two paths. The one that is more difficult (more windy, curvy, narrow, and steep) will have more coins on it.", "Instructions");
    yield return dialogue.Speech("The other one is easier but has less coins. If you fall, the game ends and you lose any of the coins you picked up. You will take turns walking the cliff.", "Instructions");
  }

  public IEnumerator EndChallenge() {
    dialogue.caller = this;
    string[] scale = new string[] { "1", "2", "3", "4", "5" };
    yield return dialogue.Menu("How stressed do you feel? (1 = not at all, 5 = very)", scale);
    yield return dialogue.Menu("How enjoyable was the activity? (1 = not at all, 5 = very)", scale);
    yield return dialogue.Menu("How supportive was your partner? (1 = not at all, 5 = very)", scale);
    yield return dialogue.Speech("Let's continue with the rest of the tour...");
    dialogue.Clear();
    Initiate.Fade("", Color.black, 0.5f);
    yield return dialogue.Speech("After touring through the cliffs for a couple more hours, you and " + GameObject.FindObjectOfType<Partner>() + " head back to your dorms.", "");
    yield return new WaitForSeconds(1.0f);
    Initiate.scr.isFadeIn = true;
    // Load next scene
    yield return null;
  }
}
