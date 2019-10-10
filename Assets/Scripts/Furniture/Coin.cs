using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Selectable
{
  new void Update() {
        base.Update();
        transform.eulerAngles = transform.eulerAngles + new Vector3(0,150 * Time.deltaTime,0);
    }
  void OnTriggerEnter(Collider coll) {
    if(coll.tag == "Player") {
        player.Coins += 1;
        Destroy(this.gameObject);
    }
  }
}

