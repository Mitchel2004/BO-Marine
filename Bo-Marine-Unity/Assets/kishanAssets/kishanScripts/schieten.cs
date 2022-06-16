using System.Collections;
using UnityEngine;

public class schieten : MonoBehaviour
{
    internal float damage = 10f;
    internal float range = 100f;
    internal float impactForce = 60f;
    private int bullets = 3;
    public bool canFire = false;
    private float timer = 2f;

    [SerializeField] Camera fpsCam;
    [SerializeField] ParticleSystem flash;
    [SerializeField] ParticleSystem blood;


    void Update()
    {
        if (canFire == true && bullets > 0 && Input.GetButtonDown("Fire2"))
        {
            shoot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            canFire = true;
        }

        if (bullets < 2)
        {
            reload();
        }

    }

    private void shoot()
    {

        flash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            target target = hit.transform.GetComponent<target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }

            Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal));
        }
        bullets--;
    }

    private void reload()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            bullets++;
            timer = 2f;
        }
    }

}