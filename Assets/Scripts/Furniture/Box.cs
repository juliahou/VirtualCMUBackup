using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Selectable
{
  public override void Action() {
    GetComponent<AudioSource>().Play();
    StartCoroutine("Unpack");
  }

  public IEnumerator Unpack() {
    transform.position = new Vector3(31f, transform.position.y, 18.5f);
    gameObject.layer = 0;
    yield return null;
  }
}
