using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dance : MonoBehaviour
{
    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F5))
        {
            animator.SetBool("isDancing",true);
        }
        else
        {
            Invoke("stopDance",2);
        }
    }
    void stopDance() {
        animator.SetBool("isDancing",false);
    }
}
