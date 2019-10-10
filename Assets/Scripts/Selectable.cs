using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
  public string hoverText = "";
  [HideInInspector]
  public PlayerScript player;
  [HideInInspector]
  public Dialogue dialogue;
  [HideInInspector]
  public CharacterData pldata, data;
  [HideInInspector]
  public string response;
  [HideInInspector]
  public int DLIndex = 0;
  public void Start() {
    if(player == null) {
      player = GameObject.FindObjectOfType<PlayerScript>();
    }
    data = GetComponent<CharacterData>();
    pldata = player.GetComponent<CharacterData>();
    dialogue = player.GetComponent<Dialogue>();
  }
  public void Update() { }
  public virtual void Action() { }
}
