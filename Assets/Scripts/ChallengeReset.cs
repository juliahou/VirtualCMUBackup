using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeReset : MonoBehaviour
{
  public GameObject Player;
  public GameObject StartPlatform;
  void OnTriggerEnter(Collider coll) {
    if(coll.tag == "Player") {
      Player.transform.position = StartPlatform.transform.position;
    }
  }
}
