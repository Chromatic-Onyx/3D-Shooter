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
    public bool canReload = true;
    // Update is called once per frame
    void Update()
    {
        
        // gun 2 reload
        if (Input.GetKeyDown(KeyCode.R) && WeaponScript.isGun2Active && Gun2ShootScript.ammoStash > 0 && canReload)
        {
            Gun2Animator.SetBool("isReloading", true);
            Gun2IsReloading = true;
            Gun2ShootScript.canShoot = false;
            Gun2ShootScript.ammo = Gun2ShootScript.magSize;
            Gun2ShootScript.ammoStash -= Gun2ShootScript.magSize;
            canReload = false;

            

        }
        // gun 1 reload
        else if (Input.GetKeyDown(KeyCode.R) && WeaponScript.isGun1Active && Gun1ShootScript.ammoStash > 0 && canReload)
        {
            Gun1Animator.SetBool("isReloading", true);
            Gun1IsReloading = true;
            Gun1ShootScript.canShoot = false;
            Gun1ShootScript.ammo = Gun1ShootScript.magSize;
            Gun1ShootScript.ammoStash -= Gun1ShootScript.magSize;
            canReload = false;
        }
        // gun 2 stop reloading
        else if (Gun2IsReloading)
        {
            Invoke("stopReloading",3f);
        }
        // gun 1 stop reloading
        else if (Gun1IsReloading)
        {
            Invoke("stopReloading", 1.2f);
        }
    }

    void stopReloading()
    {
        canReload = true;
        Gun2IsReloading = false;
        Gun1IsReloading = false;
        Gun2ShootScript.canShoot = true;
        Gun1ShootScript.canShoot = true;
        Gun2Animator.SetBool("isReloading", false);
        Gun1Animator.SetBool("isReloading", false);
        
    }
        
}
