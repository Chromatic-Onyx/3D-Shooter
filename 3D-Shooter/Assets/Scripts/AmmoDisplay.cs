using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public Shoot gun2ShootScript;
    public Shoot gun1ShootScript;
    public WeaponSwitch weaponScript;
    public Text ammo;
    public Text ammoStash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponScript.isGun2Active)
        {
            ammoStash.text = gun2ShootScript.ammoStash.ToString();
            ammo.text = gun2ShootScript.ammo.ToString() + " / " + gun2ShootScript.magSize;
        }
        else if (weaponScript.isGun1Active)
        {
            ammoStash.text = gun1ShootScript.ammoStash.ToString();
            ammo.text = gun1ShootScript.ammo.ToString() + " / " + gun1ShootScript.magSize;
        }
    }
       
}
