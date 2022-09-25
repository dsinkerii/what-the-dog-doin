using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public LineRenderer lr;
    public GameObject brick;
    public GameObject point;
    public AudioSource play;
    float tima;
    float hs;
    bool canfall;
    bool hasfall;
    bool b;
    void OnTriggerStay(Collider h)
    {
        if(h.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E)&&!canfall){
          tima = Time.time;
          canfall = true;
          StartCoroutine(fafll());
        }
    }
    IEnumerator fafll(){
      switch (hasfall){
        case false:
          transform.eulerAngles=new Vector3(0,0,Mathf.Clamp((-1.75f+(0-brick.transform.position.y))*11,0,90));
          yield return new WaitForSeconds(0.01f);
          switch (b){
            case false:
            brick.GetComponent<Rigidbody>().isKinematic=false;
            b=true;
            break;
          }
          if(Mathf.Clamp((-1.75f+(0-brick.transform.position.y))*11,0,90)==90){
            hasfall=true;
            play.Play();
          }
          lr.SetPosition(0,point.transform.position);
          lr.SetPosition(2,brick.transform.position);
          StartCoroutine(fafll());
          break;
      }
    }
}
