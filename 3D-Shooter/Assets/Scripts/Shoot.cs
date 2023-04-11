using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float range = 100f;
    private float damage = 10f;

    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootGun();
        }
    }
    void ShootGun()
    {
        RaycastHit hits;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hits, range))
        {
            Break target = hits.transform.GetComponent<Break>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
