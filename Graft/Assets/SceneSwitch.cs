using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneSwitch : MonoBehaviour
{
    public Transform camera;
    Transform player;
    BoxCollider2D m_collider;
    CinemachineVirtualCamera virtualCam;

    void Start(){
        virtualCam = camera.GetComponent<CinemachineVirtualCamera>();
        m_collider = GetComponent<BoxCollider2D>();
        m_collider.isTrigger=true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player"){
            player = col.transform;
            CenterCamera();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player"){
            PlayerAssign();
        }

    }
    void CenterCamera(){
        virtualCam.LookAt =  transform;
        virtualCam.Follow =  transform;
    }
    void PlayerAssign(){
        virtualCam.LookAt =  player;
        virtualCam.Follow =  player;
    }
}