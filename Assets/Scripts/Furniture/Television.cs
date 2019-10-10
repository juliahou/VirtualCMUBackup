using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : Selectable
{
  public Sprite gameSprite;
  public Sprite staticSprite;


  public override void Action() {
    StartCoroutine("ChooseInput");
  }

  public IEnumerator ChooseInput() {
    dialogue.caller = this;

    yield return dialogue.Menu("SOURCE", new string[] { "Cable", "HDMI1-Switch", "HDMI2-Chromecast" });
    switch(response) {
      case "HDMI1-Switch":
        GetComponentInChildren<SpriteRenderer>().sprite = gameSprite;
        Initiate.Fade("Switch", Color.white, 1.5f);
        break;
      default:
        GetComponentInChildren<SpriteRenderer>().sprite = staticSprite;
        break;
    }

    dialogue.Clear();
    yield return null;
  }
}
