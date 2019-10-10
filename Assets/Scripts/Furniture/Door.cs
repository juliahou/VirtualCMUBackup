using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Selectable
{
  public bool IsAccessible = false;
  public AudioClip open;
  public AudioClip locked;
  private float teleRadius = 1;
  
  public override void Action() {
    if(!IsAccessible) {
      StartCoroutine(DoorLock());
      return;
    }
    StartCoroutine(EnterDoor());
  }

  public IEnumerator EnterDoor() {
    GetComponent<AudioSource>().clip = open;
    GetComponent<AudioSource>().Play();
    Initiate.Fade("", Color.black, 2.0f);
    yield return new WaitForSeconds(0.5f);
    Initiate.scr.isFadeIn = true;
    Vector3 otherPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    Vector3 displacement = Vector3.zero;
    if(transform.rotation.eulerAngles.y == 0) {
      if(player.transform.position.z < transform.position.z) {
        displacement = new Vector3(0, 0, teleRadius);
      }
      else {
        displacement = new Vector3(0, 0, -teleRadius);
      }
    }
    if(transform.rotation.eulerAngles.y == 90 || transform.rotation.eulerAngles.y == -90) {
      if(player.transform.position.x < transform.position.x) {
        displacement = new Vector3(teleRadius, 0, 0);
      }
      else {
        displacement = new Vector3(-teleRadius, 0, 0);
      }
    }
    //TODO: +-45 degree angled doors
    if(transform.rotation.eulerAngles.y == 45 || transform.rotation.eulerAngles.y == -45) {
      if(player.transform.position.x < transform.position.x) {
        displacement = new Vector3(teleRadius, 0, 0);
      }
      else {
        displacement = new Vector3(-teleRadius, 0, 0);
      }
    }
    player.transform.position = otherPos + displacement;
  }

  public IEnumerator DoorLock() {
    GetComponent<AudioSource>().clip = locked;
    GetComponent<AudioSource>().Play();
    dialogue.caller = this;
    yield return dialogue.Speech("You shouldn't go through here yet.", "Locked");
    dialogue.Clear();
    yield return null;
  }
}
