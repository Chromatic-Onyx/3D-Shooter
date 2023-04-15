using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float smooth;
    public float swayMulti;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMulti;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMulti;

        Quaternion xRotation = Quaternion.AngleAxis(-mouseX, Vector3.right);
        Quaternion yRotation = Quaternion.AngleAxis(mouseY, Vector3.up);
        Quaternion target = xRotation * yRotation;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, smooth * Time.deltaTime);


    }
}
