using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Global : MonoBehaviour
{
  //Singleton instance
  private static Global _instance;
  public static Global Instance { get { return _instance; } }
  void Awake()
  {
    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    } else {
      _instance = this;
    }
  }
  public IEnumerator RestartDay() {
    hour = 0;
    minute = 0;
    second = 0;
    Initiate.Fade("",Color.white,4.0f);
    yield return new WaitForSeconds(2.0f);
    Initiate.scr.isFadeIn = true;
    hour = 0;
    minute = 0;
    second = 0;
    foreach(Transform npc in GameObject.Find("Characters").transform) {
      Activity e = npc.gameObject.GetComponent<CharacterData>().CheckSchedule(weekdays[weekday], 0, 0);
      foreach(Transform loc in GameObject.Find("Locations").transform) {
        if(loc.name == e.Location) {
          npc.position = loc.position;
          break;
        }
      }
    }
    yield return null;
  }
  //Time
  public int month = 0;
  public int day = 0;
  public int weekday = 0;
  public int hour = 0;
  public int minute = 0;
  public float second = 0;
  public string[] weekdays = {"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"};
  void Update() {
    second += Time.deltaTime * 60;
    if(second >= 60) {
      second = 0;
      minute += 1;
    }
    if(minute == 60) {
      minute = 0;
      hour += 1;
    }
    if(hour > 24) {
      hour = 0;
      day += 1;
      weekday = (weekday + 1)%7;
    }
  }
  public string TimeOfDay() {
    if(hour >= 8) {
      return "Night";
    }
    else if(hour >= 5) {
      return "Evening";
    }
    else if(hour >= 12) {
      return "Afternoon";
    }
    else if(hour >= 6) {
      return "Morning";
    }
    else if(hour >= 0) {
      return "Late Night";
    }
    return "???";
  }
  //Weather
  public string weather = "Sunny";
  public float temperature = 70;
  public string Weather() {
    if(weather == "Sunny" && (TimeOfDay() == "Night" || TimeOfDay() == "Late Night")) {
      return "Clear";
    }
    return weather;
  }
}
// //Saving
// private Save CreateSaveGameObject()
// {
//   Save save = new Save();
//   foreach(Transform NPC in GameObject.Find("Characters").transform)
//   {
//     save.NPCNames.Add(NPC.gameObject.name);
//     save.NPCPositions.Add(NPC.position);
//     save.NPCData.Add(NPC.gameObject.GetComponent<Data>());
//   }
//   return save;
// }
//
// public void SaveGame()
// {
//   Save save = CreateSaveGameObject();
//   BinaryFormatter bf = new BinaryFormatter();
//   FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
//   bf.Serialize(file, save);
//   file.Close();
//   Debug.Log("Game Saved");
// }
// public bool LoadGame()
// {
//   if(!File.Exists(Application.persistentDataPath + "/gamesave.save"))
//   {
//     return false;
//   }
//   BinaryFormatter bf = new BinaryFormatter();
//   FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
//   Save save = (Save)bf.Deserialize(file);
//   file.Close();
//   int i = 0;
//   foreach(string NPCname in save.NPCNames)
//   {
//     Transform NPC = GameObject.Find("Characters").transform.Find(NPCname);
//     NPC.position = save.NPCPositions[i];
//     Destroy(NPC.gameObject.GetComponent<Data>());
//     NPC.GetComponent<Data>().OverwriteData(save.NPCData[i]);
//     i++;
//   }
//   return true;
// }
