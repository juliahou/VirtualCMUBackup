using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fake partner character
public class Partner : NPC
{
  public override void Action() {
    if(DLIndex == 1) {
      StartCoroutine(CliffDifficulty());
    }
    else {
      StartCoroutine(CliffDialogue());
    }
  }

  public IEnumerator DefaultDialogue() {
    dialogue.caller = this;

    yield return dialogue.Speech("Hello");

    yield return dialogue.Menu("What's up?", new string[] { "Nothing" });
    switch(response) {
      case "Nothing":
        break;
      default:
        break;
    }
    dialogue.Clear();
    yield return null;
  }

  public IEnumerator CliffDialogue() {
    dialogue.caller = this;
    yield return dialogue.Menu("Choose Dialogue", new string[]{
      "Hey " + player.PartnerName + ".",
      "Are you ready for this?",
      "This is super exciting.",
      "I'm pretty nervous..."
    });
    StartCoroutine(dialogue.Speech("Partner is selecting dialogue option..."));
    yield return new WaitForSeconds(2.5f);
    yield return dialogue.Speech("It'll be fun! Let's do this!");
    dialogue.Clear();
    yield return null;
  }

  public IEnumerator CliffDifficulty() {
    dialogue.caller = this;
    StartCoroutine(dialogue.Speech("Partner is selecting dialogue option..."));
    yield return new WaitForSeconds(3.5f);
    // if(touch) {
    yield return dialogue.Speech("So what are you thinking " + player.Name + "? Do you want to try the harder one ?");
    // }
    // if(verbal) {
    //   yield return dialogue.Speech("So what are you thinking of doing " + player.Name + "? Do you want to try the harder one to get more coins? You'll do great - and I bet you will enjoy the challenge.");
    // }

    yield return dialogue.Menu("[So what are you thinking of doing?]", new string[]{
      "Hm, I'm not sure " + player.Name + ".",
      "I think I can do the harder one!",
      "Maybe I'll do the easier one...",
      "I don't think I want to do this."
    });

    StartCoroutine(dialogue.Speech("Partner is selecting dialogue option..."));
    yield return new WaitForSeconds(1.75f);
    yield return dialogue.Speech("Alright");

    yield return dialogue.Menu("Choose difficulty", new string[]{
      "Harder",
      "Easier",
      "Neither"
    });

    string[] options = new string[] { };
    switch(response) {
      case "Harder":
        options = new string[] {
          "I want the coins",
          "I want to feel challenged",
          "I feel capable of doing well.",
          "I like adventure",
        };
        break;
      case "Easier":
        options = new string[] {
          "I prefer the safer option.",
          "I don't like heights.",
          "I don't want to disappoint " + name,
          "I don't want to disappoint myself",
        };
        break;
      default:
        options = new string[] {
          "I prefer the safer option.",
          "I don't like heights.",
          "I don't want to disappoint " + name,
          "I don't want to disappoint myself",
        };
        break;
    }
    yield return dialogue.Menu("I made that decision because...", options);

    yield return dialogue.Menu("I feel...", new string[]{
      "Very secure",
      "Secure",
      "Insecure"
    });
    player.Locked = false;
    dialogue.Clear();
    yield return null;
  }
}
