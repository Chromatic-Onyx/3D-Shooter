using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Animator gun2Animator;
    public Camera Camera;
    public bool canZoomOut = false;
    public bool isAiming;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            gun2Animator.SetBool("isAiming", true);
            Invoke("zoomin", 0.3f);
            isAiming = true;

        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) && canZoomOut)
        {
            gun2Animator.SetBool("isAiming", false);
            isAiming = false;
            zoomout();
            canZoomOut = false;
        }
    }

    void zoomin()
    {
        Camera.fieldOfView = 30;
        canZoomOut = true;
    }
    void zoomout()
    {
        Camera.fieldOfView = 50;
    }
}
