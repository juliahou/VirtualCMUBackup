using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Selectable
{


  public override void Action() {
    StartCoroutine("ChooseFloor");
  }

  public IEnumerator ChooseFloor() {
    dialogue.caller = this;

    yield return dialogue.Menu("Which floor?", new string[] { "5", "1" });
    switch(response) {
      case "5":
        pldata.Location = "MW5";
        break;
      case "1":
        pldata.Location = "MW1";
        break;
    }

    dialogue.Clear();
    yield return null;
  }
}
