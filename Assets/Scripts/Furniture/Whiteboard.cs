using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : Selectable
{
  public override void Action() {
    StartCoroutine(Draw());
  }

  public IEnumerator Draw() {
      yield return null;
  }
}
