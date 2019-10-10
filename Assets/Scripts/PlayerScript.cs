using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
  public bool Locked = false;
  public float Speed;
  public int Coins = 0;
  public GameObject Cam;
  public GameObject OVRCam;
  public Text HoverTextObj;
  [HideInInspector]
  public Dialogue dialogue;
  [HideInInspector]
  public string Name, PartnerName;
  [HideInInspector]
  public Quests quests;

  [HideInInspector]
  public GameObject Target;
  private float maxDistance = 1.75f;
  private LayerMask ignoreLayerMask;
  void Start() {
    ignoreLayerMask = LayerMask.GetMask("Selectable");
    dialogue = GetComponent<Dialogue>();
    quests = GetComponent<Quests>();
    quests.AddQuest("Interact with objects (0/3)");
    Name = "Isaac";
    PartnerName = "Eric";
  }
  void Update() {
    if(!Locked) {
      ProcessMovement();
    }
    OVRCam.transform.position = Cam.transform.position;
    //Update hover text on Target object
    if(HoverTextObj != null) {
      if(Target == null || Target.GetComponent<Selectable>() == null || dialogue.isActive != DL.None) {
        HoverTextObj.text = "";
      }
      else {
        HoverTextObj.text = Target.GetComponent<Selectable>().hoverText;
      }
    }
    //Activate Target object action
    if(Input.GetKeyDown("e") && Target != null && dialogue.isActive == DL.None) {
      if(Target.GetComponent<Selectable>() != null) {
        Target.GetComponent<Selectable>().Action();
      }
    }
  }
  void FixedUpdate() {
    //Check for Target object
    RaycastHit hit;
    // Debug.DrawRay(Cam.transform.position, Cam.transform.forward*maxDistance, Color.red);
    if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, maxDistance, ignoreLayerMask)) {
      if(Target != null && Target != hit.collider.gameObject) {
        if(Target.GetComponent<Outline>() != null) {
          Target.GetComponent<Outline>().enabled = false;
        }
      }
      Target = hit.collider.gameObject;
      if(Target.GetComponent<Outline>() != null) {
        Target.GetComponent<Outline>().enabled = true;
      }
    }
    else if(Target != null) {
      if(Target.GetComponent<Outline>() != null) {
        Target.GetComponent<Outline>().enabled = false;
      }
      Target = null;
    }
  }
  void ProcessMovement() {
    if(dialogue.isActive != DL.None) {
      return;
    }
    Vector3 horiz = Speed * transform.right * Time.deltaTime;
    horiz = new Vector3(horiz.x, 0, horiz.z);
    Vector3 vert = Speed * transform.forward * Time.deltaTime;
    vert = new Vector3(vert.x, 0, vert.z);

    Vector3 OVRhoriz = Speed * OVRCam.transform.right * Time.deltaTime;
    OVRhoriz = new Vector3(OVRhoriz.x, 0, OVRhoriz.z);
    Vector3 OVRvert = Speed * OVRCam.transform.forward * Time.deltaTime;
    OVRvert = new Vector3(OVRvert.x, 0, OVRvert.z);

    //float difference = 0.2f;
    //Vector3 original = OVRCam.transform.position;

    if(Input.GetAxis("Horizontal") > 0) {
      transform.position += horiz;
      //OVRCam.transform.position += OVRhoriz;
    }
    if(Input.GetAxis("Horizontal") < 0) {
      transform.position -= horiz;
      //OVRCam.transform.position -= OVRhoriz;
    }
    if(Input.GetAxis("Vertical") > 0) {
      transform.position += vert;
      //OVRCam.transform.position += OVRvert;
    }
    if(Input.GetAxis("Vertical") < 0) {
      transform.position -= vert;
      //OVRCam.transform.position -= OVRvert;
    }

    //if (OVRCam.transform.position.z - transform.position.z > difference) {
    //    OVRCam.transform.position = original;
    //}
  }
}
