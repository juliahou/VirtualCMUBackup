using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : Selectable
{
  public override void Action() {
    StartCoroutine("ChangeClothes");
  }

  public IEnumerator ChangeClothes() {
    dialogue.caller = this;
    yield return dialogue.Speech("You have no clothes.", "Dresser");
    dialogue.Clear();
    yield return null;
  }
}
