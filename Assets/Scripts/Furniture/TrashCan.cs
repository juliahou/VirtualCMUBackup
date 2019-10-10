using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Selectable
{


    public override void Action() {
      StartCoroutine("YouAreTrash");
    }

    public IEnumerator YouAreTrash() {
      // player.GetComponent<Collider>().enabled = false;
      // player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
      // Vector3 oldPosition = player.transform0.position;
      // player.transform.position = transform.position;
      // player.transform.rotation = transform.rotation;
      yield return null;
      // yield return new WaitForSeconds(2.5f);
      // player.transform.position = oldPosition;
      // player.GetComponent<Collider>().enabled = true;
      // player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
