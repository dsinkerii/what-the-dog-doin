using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenwint : MonoBehaviour
{
    public GameObject key;
    public AudioSource play;
    void OnTriggerStay(Collider h)
    {
      if(h.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E)&&key==null){
        Destroy(this.gameObject);play.Play();
      }}
}
