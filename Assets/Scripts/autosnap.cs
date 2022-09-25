using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autosnap : MonoBehaviour
{
    public Transform camPoint;
    void Update()
    {
      RaycastHit hit;
      if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit,3.5f)){
        camPoint.transform.position=hit.point+camPoint.transform.forward*0.5f;
      }else{
      camPoint.transform.localPosition=new Vector3(0,0,-3.5f);
      }
    }
}
