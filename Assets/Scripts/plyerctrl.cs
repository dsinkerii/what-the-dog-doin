using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyerctrl : MonoBehaviour
{
  public float xrot;
  public float yrot;
  public CharacterController rockler;
  public Transform camPoint;
  public Transform camC;
  public GameObject qd;
  public GameObject qd2;
  public GameObject volumes;
  public Transform[] tg;
  public AudioSource[] asf;
  public int running;
  public ParticleSystem[] systems;
  float h;
  Vector3 ec;
  public int status;
  public bool move;
  void Start()
{
  Application.targetFrameRate=60;
    Cursor.lockState = CursorLockMode.Locked;
}
    void Update()
    {
      xrot += Input.GetAxis("Mouse X");
      yrot -= Input.GetAxis("Mouse Y");
      switch(Input.GetKeyDown(KeyCode.P)){
        case true:
          qd2.SetActive(!System.Convert.ToBoolean(status));
          status=System.Convert.ToInt32(!System.Convert.ToBoolean(status));
          qd.SetActive(System.Convert.ToBoolean(status));
          volumes.SetActive(!System.Convert.ToBoolean(status));
          break;
      }
      switch (move){
      case true:
        Cursor.lockState = CursorLockMode.Locked;
        switch (status){
          case 1:
            yrot = Mathf.Clamp(yrot, -15f, 45f);
            float xsh = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")).normalized/25).x;
            float xsz = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")).normalized/25).z;
            float ns = (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")))*2+1;
            camC.localRotation = Quaternion.Lerp(camC.localRotation,Quaternion.Euler(yrot*2+Mathf.Sin(Mathf.Lerp(0,Random.Range(-1f,1f)*ns,0.2f))*10, 0, 0),0.2f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.Euler(0,xrot*2+Mathf.Sin(Mathf.Lerp(0,Random.Range(-1f,1f)*ns,0.2f))*10, 0),0.2f);
            rockler.Move(new Vector3(xsh,0,xsz));
            rockler.Move(new Vector3(0,-7.97f/3,0)*Time.deltaTime);
            break;
          case 0://classic
          yrot = Mathf.Clamp(yrot, -10f, 10f);
            camC.localRotation  = Quaternion.Euler(7.688f,0,0);
            h = Mathf.Abs(Input.GetAxis("Vertical"))+ Mathf.Abs(Input.GetAxis("Horizontal"));
            float xh = camPoint.TransformDirection(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")).normalized/35).x;
            float xz = camPoint.TransformDirection(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")).normalized/35).z;
            if (running == 0&&h!=0){
              StartCoroutine(ruhn());
              running=1;
            }
            if(h!=0)
              transform.forward=Vector3.Lerp(transform.forward,new Vector3(xh,0,xz),45*Time.deltaTime);
            rockler.Move(new Vector3(xh,0,xz));
            camPoint.transform.localRotation = Quaternion.Lerp(camPoint.transform.localRotation,Quaternion.Euler(yrot*5, xrot*5, 0),0.2f);
            camPoint.transform.position=transform.position+new Vector3(0,0.75f,0);
            rockler.Move(new Vector3(0,-7.97f/3,0)*Time.deltaTime);
            break;
      }
      break;
    case false:
      Cursor.lockState = CursorLockMode.Confined;
      break;
  }

}
    IEnumerator ruhn(){
      if(h!=0){
          for(int one = 0; one<= 20;one++){
          tg[0].localPosition =Vector3.Lerp(tg[0].localPosition,new Vector3(0.13f,0.1224f,0.423f),20*Time.deltaTime);
          tg[1].localPosition =Vector3.Lerp(tg[1].localPosition,new Vector3(-0.13f,0.0224f,0.423f),20*Time.deltaTime);
          tg[2].localPosition =Vector3.Lerp(tg[2].localPosition,new Vector3(0.13f,0.0224f,-0.327f),20*Time.deltaTime);
          tg[3].localPosition =Vector3.Lerp(tg[3].localPosition,new Vector3(-0.13f,0.1224f,-0.327f),20*Time.deltaTime);
          yield return new WaitForSeconds(.0001f);
        }
        systems[3].Play();
        systems[0].Play();
        asf[0].Play();
        for(int one = 0; one<= 20;one++){
        tg[0].localPosition =Vector3.Lerp(tg[0].localPosition,new Vector3(0.13f,0.0224f,0.423f),20*Time.deltaTime);
        tg[1].localPosition =Vector3.Lerp(tg[1].localPosition,new Vector3(-0.13f,0.1224f,0.423f),20*Time.deltaTime);
        tg[2].localPosition =Vector3.Lerp(tg[2].localPosition,new Vector3(0.13f,0.1224f,-0.327f),20*Time.deltaTime);
        tg[3].localPosition =Vector3.Lerp(tg[3].localPosition,new Vector3(-0.13f,0.0224f,-0.327f),20*Time.deltaTime);
        yield return new WaitForSeconds(.0001f);
      }systems[1].Play();
      systems[2].Play();
      asf[1].Play();
        StartCoroutine(ruhn());}else{
          tg[0].localPosition =Vector3.Lerp(tg[0].localPosition,new Vector3(0.13f,0.0224f,0.423f),100*Time.deltaTime);
          tg[1].localPosition =Vector3.Lerp(tg[1].localPosition,new Vector3(-0.13f,0.0224f,0.423f),100*Time.deltaTime);
          tg[2].localPosition =Vector3.Lerp(tg[2].localPosition,new Vector3(0.13f,0.0224f,-0.327f),100*Time.deltaTime);
          tg[3].localPosition =Vector3.Lerp(tg[3].localPosition,new Vector3(-0.13f,0.0224f,-0.327f),100*Time.deltaTime);
          running=0;
        }
    }
}
