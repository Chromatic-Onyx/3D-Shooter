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

    public GameObject gun2;
    public float smooth = 5f;

    public int rotateCount = 0;
    public bool justShot = false;
    int rotateScale = 1;
    public float verticalRecoil = 0.5f;
    public float horizontalRecoil = 0.5f;

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
                justShot = true;

            }

        }
        else if (justShot && !Input.GetButton("Fire1"))
        {
            stopRecoil();
        }
    }

    void ShootGun()
    {
        muzzleFlash.Play();
        recoil();
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

    void recoil()
    {
        rotateScale++;
        Vector3 rotationVector = new Vector3(0f, 0f, -verticalRecoil);
        gun2.transform.Rotate(rotationVector);
        if (rotateScale % 2 == 1)
        {
            gun2.transform.Rotate(new Vector3(0f, horizontalRecoil, 0f));
        }
        else if (rotateScale % 2 == 0)
        {
            gun2.transform.Rotate(new Vector3(0f, -horizontalRecoil, 0f));
        }
        rotateCount += 1;
        
    }

    void stopRecoil()
    {
        
        gun2.transform.Rotate(new Vector3(0f, 0f, verticalRecoil * rotateCount));
        if (rotateScale % 2 == 1)
        {
            gun2.transform.Rotate(new Vector3(0f, -horizontalRecoil, 0f));
        }
        else if (rotateScale % 2 == 0)
        {
            gun2.transform.Rotate(new Vector3(0f, horizontalRecoil, 0f));
        }
        justShot = false;
        rotateCount = 0;
        rotateScale = 0;
    }

   
}
