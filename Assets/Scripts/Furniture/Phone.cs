using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Selectable
{
  private bool isRinging = true;
  public override void Action() {
    Ring();
    StartCoroutine(PhoneDialogue());
  }
  public IEnumerator PhoneDialogue() {
    dialogue.caller = this;
    if(!isRinging) {
      yield return dialogue.Speech("You have 0 voice messages.");
    }
    else {
      yield return dialogue.Speech("Hey! I was thinking, before we start class on Monday, Pittsburgh Connections has a park tour we should do. Meet me tomorrow at the Natural Cliffs park at 1:00?", name = player.PartnerName);
      yield return dialogue.Menu("Meet at the park?", new string[] { "Sounds good.", "Hmm, I’m not sure", "See you there!" });
      StartCoroutine(dialogue.Speech("Partner is selecting dialogue option...", name = player.PartnerName));
      yield return new WaitForSeconds(1.75f);
      yield return dialogue.Speech("It’ll be fun. See you tomorrow!", name = player.PartnerName);
      Initiate.Fade("", Color.black, 2.0f);
      yield return new WaitForSeconds(1.0f);
      Initiate.scr.isFadeIn = true;
    }
    dialogue.Clear();
    isRinging = false;
    yield return null;
    
  }
  public void Ring() {
    GetComponent<AudioSource>().Play();
  }
}
