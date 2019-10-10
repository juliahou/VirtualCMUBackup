using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
  public GameObject QuestTextPrefab;
  private PlayerScript player;
  private List<string> quests;
  void Start() {
    player = GameObject.FindObjectOfType<PlayerScript>();
  }
  public void AddQuest(string s) {
    if(quests == null)
      quests = new List<string>();
    quests.Add(s);
    resetQuestPositions();
  }

  public void RemoveQuest(string s) {
    quests.Remove(s);
    Destroy(GameObject.Find("Quest_" + s));
    resetQuestPositions();
  }

  private void resetQuestPositions() {
    for(int i = 0; i < quests.Count; i++) {
      string s = quests[i];
      GameObject txt = Instantiate(QuestTextPrefab, Vector3.zero, Quaternion.identity);
      var rectTransform = txt.GetComponent<RectTransform>();
      var baseTransform = QuestTextPrefab.GetComponent<RectTransform>();
      rectTransform.SetParent(GameObject.Find("Quests").transform);
      rectTransform.anchoredPosition = new Vector2(baseTransform.anchoredPosition.x, baseTransform.anchoredPosition.y - 50 * i);
      rectTransform.localScale = new Vector3(1, 1, 1);
      rectTransform.sizeDelta = baseTransform.sizeDelta;
      txt.GetComponent<Text>().text = s;
      txt.name = "Quest_" + s;
    }
  }
}
