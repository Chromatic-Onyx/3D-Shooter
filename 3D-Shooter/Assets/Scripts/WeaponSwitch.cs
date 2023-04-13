using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;
    public bool isGun1Active;
    public bool isGun2Active;
    // Start is called before the first frame update
    void Start()
    {
        gun1.SetActive(false);
        gun2.SetActive(true);
        isGun1Active = false;
        isGun2Active = true;
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
            isGun1Active = true;
            isGun2Active = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
            isGun1Active = false;
            isGun2Active = true;
        }
    }
}
