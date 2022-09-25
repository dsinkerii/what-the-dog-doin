using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTON : MonoBehaviour
{
  public battarytaker bt;
  public Transform Lift;
  public GameObject pal;
  public GameObject pal2;
  public AudioSource play;
  bool hasfall;
  float tim;
  bool hasfall2;
  void OnTriggerStay(Collider h)
  {
    if(h.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E)&&bt.Battary==null&&!hasfall){
      hasfall=true;
      tim = Time.time;
      Lift.gameObject.SetActive(true);
      play.Play();
      StartCoroutine(po());
    }
  }
  IEnumerator po(){
    switch (hasfall2){
      case false:
      Lift.position = new Vector3(-18.65f,Mathf.Abs(Mathf.Sin(Time.time-tim+1)*10)-2,-10.48f);
      if(Time.time-tim>=2){
        pal.transform.SetParent(Lift);
        pal.transform.localPosition=new Vector3(pal.transform.localPosition.x,0,pal.transform.localPosition.z);
      }if(Time.time-tim>=3){
        Lift.gameObject.SetActive(false);
        hasfall2=true;
        pal2.SetActive(true);
      }
        yield return new  WaitForSeconds(0.01f);
        StartCoroutine(po());
        break;
    }
  }
}
