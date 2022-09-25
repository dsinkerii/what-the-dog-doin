using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
  public AudioSource play;
  public bool isbat;
  public GameObject cube;
  public Material sw;
  void OnTriggerStay(Collider hs)
  {
    if(hs.gameObject.tag == "Player"&&Input.GetKeyDown(KeyCode.E)){
      if(isbat){
        cube.GetComponent<MeshRenderer>().material=sw;
      }
      Destroy(this.gameObject);
      play.Play();
    }
  }
}
