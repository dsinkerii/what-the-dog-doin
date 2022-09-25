using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
  public GameObject Key;
  public AudioSource play;
  bool f;
  void OnTriggerStay(Collider h)
  {
    if(h.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E)&&Key==null&&!f){
      transform.eulerAngles=new Vector3(0,220,0);f=true;
      play.Play();
    }
  }
}
