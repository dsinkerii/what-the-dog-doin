using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buton : MonoBehaviour
{
  public Transform s;
  public AudioSource play;
  void OnTriggerStay(Collider hs)
  {
    if(hs.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E)){
        s.eulerAngles=new Vector3(0,-90,-90);
        play.Play();
      }}
}
