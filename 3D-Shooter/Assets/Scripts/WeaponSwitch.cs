using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
        }
    }
}
