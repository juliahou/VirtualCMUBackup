using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity
{
  public string Weekday;
  public int Hour;
  public int Minute;
  public int Second;
  public string Name;
  public string Location;
  public string Sublocation;
  public Activity(string l, int h, int m)
  {
    Hour = h;
    Minute = m;
    Second = 0;
    Name = "";
    Location = l;
    Sublocation = "";
  }
}

public class CharacterData : MonoBehaviour
{
  public string Name = "Isaac";
  //Player's current location (MW5, MW1, DH2)
  public string Location = "MW5";
  public float GPA = 4.0f;
  public float Sleep = 10.0f;
  public float Stress = 0.0f;
  public List<GameObject> Inventory;
  public List<Activity> Schedule = new List<Activity>();

  public Activity CheckSchedule(string weekday, int hour, int minute)
  {
    Activity e = new Activity("", 0, 0);
    bool wdfound = false;
    foreach (Activity evt in Schedule)
    {
      if (evt.Weekday != weekday)
      {
        if (wdfound)
        {
          return e;
        }
        continue;
      }
      wdfound = true;
      if (evt.Hour > hour || (evt.Hour == hour && evt.Minute >= minute))
      {
        return e;
      }
      else
      {
        e = evt;
      }
    }
    return e;
  }
}