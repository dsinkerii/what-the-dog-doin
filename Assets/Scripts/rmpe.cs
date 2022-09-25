using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rmpe : MonoBehaviour
{
  public GameObject g;
  public plyerctrl pc;
  public AudioSource play;
  bool h;
    void OnTriggerEnter(Collider s)
    {
        if(s.gameObject.tag == "Player"){
          g.SetActive(true);
        }
    }
    void OnTriggerStay(Collider s)
    {
        if(s.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E)){
          h=!h;
          pc.move = h;
        }
    }
    void OnTriggerExit(Collider s)
    {
        if(s.gameObject.tag == "Player"){
          if(g.active)
            play.Play();
          g.SetActive(false);
        }
    }
}
