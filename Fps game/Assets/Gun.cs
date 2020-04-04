
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 10f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject pistol;

    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
           
            Shoot();
            
            nextTimeToFire = Time.time + fireRate;
            
        }    
    }

    void Shoot(){

        muzzleFlash.Play();
        pistol.GetComponent<Animator>().Play("gunshot");
        RaycastHit shot;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out shot, range))
        {
            
            Target target = shot.transform.GetComponent<Target>();// get the conponent = the transform of the ray when it hits sonthing
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (target != null)
            {
                shot.rigidbody.AddForce(-shot.normal * impactForce);
            }
            
                GameObject impactGO = Instantiate(impactEffect, shot.point, Quaternion.LookRotation(shot.normal));

                Destroy(impactGO, 2f);

            
            
            
        }


    }
}
