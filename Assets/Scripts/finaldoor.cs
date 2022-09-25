using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finaldoor : MonoBehaviour
{
  public GameObject[] bt;
  public AudioSource j;
  float h;
  void OnTriggerStay(Collider h)
  {
    if(h.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E)&&bt[0]==null&&bt[1]==null&&bt[2]==null&&bt[3]==null&&bt[4]==null){
      StartCoroutine(ho());
      j.Play();
    }
  }
  IEnumerator ho(){
    if(h<=5){
    transform.eulerAngles=Vector3.Lerp(transform.eulerAngles,new Vector3(0,90,0),0.003f);
    yield return new WaitForSeconds(0.005f);
    h+=0.01f;
    StartCoroutine(ho());
    }else{
    SceneManager.LoadScene("End");}
  }
}
