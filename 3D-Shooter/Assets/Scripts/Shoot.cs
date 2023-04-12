using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] int fireRate = 4;
    private float lastFired = 0f;

    public Camera cam;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && (Time.time - lastFired > 1f / fireRate))
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
