using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public Animator Gun2Animator;
    public Animator Gun1Animator;
    public Shoot Gun2ShootScript;
    public Shoot Gun1ShootScript;
    public WeaponSwitch WeaponScript;
    public bool Gun1IsReloading = false;
    public bool Gun2IsReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && WeaponScript.isGun2Active)
        {
            Gun2Animator.SetBool("isReloading", true);
            Gun2IsReloading = true;
            Gun2ShootScript.canShoot = false;
            
        }
        else if (Input.GetKeyDown(KeyCode.R) && WeaponScript.isGun1Active)
        {
            Gun1Animator.SetBool("isReloading", true);
            Gun1IsReloading = true;
            Gun1ShootScript.canShoot = false;
        }
        else if (Gun2IsReloading)
        {
            Invoke("stopReloading",3f);
        }
        else if (Gun1IsReloading)
        {
            Invoke("stopReloading", 1.2f);
        }
    }

    void stopReloading()
    {
        Gun2IsReloading = false;
        Gun1IsReloading = false;
        Gun2ShootScript.canShoot = true;
        Gun1ShootScript.canShoot = true;
        Gun2Animator.SetBool("isReloading", false);
        Gun1Animator.SetBool("isReloading", false);
        
    }
        
}
