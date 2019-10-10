using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeEnd : MonoBehaviour
{
  void OnTriggerEnter(Collider coll) {
    if(coll.tag == "Player") {
      StartCoroutine(GameObject.FindObjectOfType<TourGuide>().EndChallenge());
      GameObject.FindObjectOfType<PlayerScript>().quests.RemoveQuest("Cliff Crossing");
    }
  }
}
