using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Selectable
{

  public override void Action() {
    player.GetComponent<Dialogue>().DefaultNPCDialogue(this);
  }
}
