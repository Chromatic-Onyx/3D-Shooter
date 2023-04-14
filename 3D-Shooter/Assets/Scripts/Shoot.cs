using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] int fireRate = 4;
    private float lastFired = 0f;
    public Camera cam;
    public ParticleSystem muzzleFlash;

    public bool canShoot = true;
    public int ammo = 40;
    public int magSize = 40;
    public int ammoStash = 999;
    
    // Update is called once per frame
    void Update()
    {
        if (ammo <= 0)
        {
            canShoot = false;
        }

        if (canShoot && Input.GetButton("Fire1") && (Time.time - lastFired > 1f / fireRate))
        {

            if (Time.time - lastFired > 1f / fireRate)
            {
                lastFired = Time.time;
                ShootGun();
            }

        }
    }

    void ShootGun()
    {
        muzzleFlash.Play();
        ammo -= 1;
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
