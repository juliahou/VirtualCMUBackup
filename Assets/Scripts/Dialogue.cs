using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*--------------------------------------------------------------------------------
  Standard Practice for dialogue

  // First line of top-level coroutine (set speaker):
  dialogue.caller = this;
  // Stuff, recursive calls, whatever
  // Last lines of bottom-level coroutine (resume gameplay):
  dialogue.Clear();
  yield return null;
------------Speech--------------------------------------------------------------
  yield return dialogue.Speech("I'll meet you in the lounge.");
  //Other stuff
--------------------------------------------------------------------------------

------------Menus---------------------------------------------------------------
Don't use a blank option in a menu or it will soft lock! Just use "..." or something
  yield return dialogue.Menu("What option do you choose?", new string[]{
    "1",
    "Two",
    "C"
  });
  switch(dialogue.response) {
    case "1":
    //Calls to other dialogue coroutines, etc.
    break;
    case "Two":
    //Calls to other dialogue coroutines, etc.
    break;
    default:
    //Calls to other dialogue coroutines, cancel, etc.
    break;
  }
------------------------------------------------------------------------------*/
public enum DL { None, Menu, Speech };

public class Dialogue : MonoBehaviour
{
  public DL isActive = 0;
  public Selectable caller;
  public Text menuTitleText;
  public GameObject dialoguePanel;
  public Text dialogueTitle;
  public Text dialogueText;
  public Button menuOptionPrefab;
  private bool click = false;
  void Update() {
    if(Input.GetMouseButtonDown(0)) {
      click = true;
    }
  }
  public IEnumerator Speech(string text, string name = "") {
    Erase();
    isActive = DL.Speech;
    dialoguePanel.SetActive(true);
    dialogueTitle.text = name;
    if(caller != null && name == "") {
      dialogueTitle.text = caller.name;
    }
    dialogueText.text = text;
    yield return WaitForAdvance();
  }
  public IEnumerator Menu(string title, string[] options) {
    Erase();
    caller.response = "";
    isActive = DL.Menu;
    menuTitleText.text = title;
    for(int i = 0; i < options.Length; i++) {
      CreateButton(options[i], i);
    }
    yield return WaitForAdvance();
  }
  public void Erase() {
    click = false;
    if(menuTitleText != null) {
      menuTitleText.text = "";
    }
    if(dialogueTitle != null) {
      dialogueTitle.text = "";
    }
    if(dialogueText != null) {
      dialogueText.text = "";
    }
    if(dialoguePanel != null) {
      dialoguePanel.SetActive(false);
    }
    if(GameObject.Find("Canvas") != null) {
      foreach(Transform child in GameObject.Find("Canvas").transform) {
        if(child.name == "MenuOption") {
          Destroy(child.gameObject);
        }
      }
    }
  }
  public void Clear() {
    Erase();
    isActive = DL.None;
  }
  public void CreateButton(string s, int i) {
    Button button = Instantiate(menuOptionPrefab, Vector3.zero, Quaternion.identity);
    var rectTransform = button.GetComponent<RectTransform>();
    var baseTransform = menuOptionPrefab.GetComponent<RectTransform>();
    rectTransform.SetParent(GameObject.Find("Canvas").transform);
    rectTransform.anchoredPosition = new Vector2(baseTransform.anchoredPosition.x, baseTransform.anchoredPosition.y - 30 * i);
    rectTransform.localScale = new Vector3(1, 1, 1);
    rectTransform.sizeDelta = baseTransform.sizeDelta;
    button.GetComponentInChildren<Text>().text = s;
    button.onClick.AddListener(() => { ChooseOption(s); });
    button.name = "MenuOption";
  }
  public void ChooseOption(string s) {
    menuTitleText.text = "";
    Erase();
    if(caller != null) {
      caller.response = s;
    }
  }

  public IEnumerator WaitForAdvance() {
    if(isActive == DL.Speech) {
      while(!click) {
        yield return new WaitForEndOfFrame();
      }
      click = false;
    }
    else if(isActive == DL.Menu) {
      while(caller.response == "") {
        yield return new WaitForEndOfFrame();
      }
    }
    yield return new WaitForSeconds(0.1f);
  }

  //Quick dialogue presets
  public void DefaultNPCDialogue(Selectable c) {
    caller = c;
    Speech("Hello");
  }
}
