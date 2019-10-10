using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Selectable
{
  public AudioClip jazz;
  public AudioClip classical;
  public AudioClip ballroom;
  private AudioSource music;

  new void Start() {
    music = GetComponent<AudioSource>();
    base.Start();
  }

  public override void Action() {
    StartCoroutine(PlayMusic());
  }

  IEnumerator PlayMusic() {
    dialogue.caller = this;
    music.Stop();
    yield return dialogue.Menu("Library", new string[] { "Acid Trumpet", "Gymnopedie No. 1", "Hyperfun" });
    switch(response) {
      case "Acid Trumpet":
        music.clip = jazz;
        break;
      case "Gymnopedie No. 1":
        music.clip = classical;
        break;
      case "Hyperfun":
        music.clip = ballroom;
        break;
    }
    dialogue.Clear();
    music.Play();
  }
  //   Music from https://filmmusic.io
  // "Hyperfun" by Kevin MacLeod(https://incompetech.com)
  // "Acid Trumpet" by Kevin MacLeod(https://incompetech.com)
  // "Gymnopedie No. 1" by Kevin MacLeod(https://incompetech.com)
  // License: CC BY (http://creativecommons.org/licenses/by/4.0/)
}
