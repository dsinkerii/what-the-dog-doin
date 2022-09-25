using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battarytaker : MonoBehaviour
{
  public GameObject Battary;
  public GameObject pole;
  public GameObject pole2;
  public AudioSource play;
bool hasfall;
  void OnTriggerStay(Collider h)
  {
    if(h.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E)&&Battary!=null){
      Destroy(Battary);
      StartCoroutine(po());
      play.Play();
    }}
    IEnumerator po(){
      switch (hasfall){
        case false:
        pole.transform.eulerAngles=Vector3.Lerp(pole.transform.eulerAngles,new Vector3(90,0,0),0.1f);
        yield return new  WaitForSeconds(0.01f);
        pole2.transform.localPosition= Vector3.Lerp(pole2.transform.localPosition,new Vector3(0.25f,2.415f,-1.383f),0.1f);
        StartCoroutine(po());
        if(pole.transform.eulerAngles.x >= 89f){
          hasfall=true;
        }
        break;
      }
    }
}
