using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Selectable
{
  public override void Action() {
    GetComponent<AudioSource>().Play();
    GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
  }
}
