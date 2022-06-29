using System.Collections;
using UnityEngine;

public class schieten : MonoBehaviour
{
    public float ShootDamage = 2f;
    private float range = 350f;
    private int bullets = 3;
    public static bool canFire = false;
    [SerializeField] private float timer = 0f;
    [SerializeField] LayerMask enemyLayer;

    [SerializeField] GameObject ThirdPersonCamera;
    [SerializeField] GameObject fpsCam;
    [SerializeField] ParticleSystem flash;
    [SerializeField] ParticleSystem blood;
    public Animator animator;


    void Update()
    {
        if (canFire == true && bullets > 0 && Input.GetButtonDown("Fire2"))
        {
            shoot();
            animator.SetTrigger("Shoot");
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

    void OnDrawGizmosSelected()
    {
        // Draws a blue line from this transform to the target
        Vector3 pos = new Vector3();
        pos.x = 0;
        pos.y = 0;
        pos.z = range;

        pos = Quaternion.Euler(ThirdPersonCamera.transform.localEulerAngles.x, transform.localEulerAngles.y, 0) * pos;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(fpsCam.transform.position, fpsCam.transform.position + pos);

        Debug.Log("DRAWLINE");
        Vector3 pos2 = Quaternion.Euler(ThirdPersonCamera.transform.localEulerAngles.x, transform.localEulerAngles.y, 0) * new Vector3(0,0,1);
    }

    private void shoot()
    {
        timer -= Time.deltaTime;
        RaycastHit hit;
        bool hitSomething = Physics.Raycast(fpsCam.transform.position, Quaternion.Euler(ThirdPersonCamera.transform.localEulerAngles.x, transform.localEulerAngles.y, 0) * new Vector3(0, 0, 1), out hit, range, enemyLayer);
        Debug.DrawLine(fpsCam.transform.position, hit.transform.position, Color.red, 1f);
        

        if (hitSomething)
        {
            //Debug.Log(hit.transform.name);
           

            target target = hit.transform.GetComponent<target>();
            if (target != null)
            {
                target.health -= ShootDamage;
                Debug.Log(target.health);
            }

            Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal));
        }
        /*if (timer <= 0)
        {
            flash.Play();

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Debug.DrawLine(fpsCam.transform.position, hit.transform.position, Color.red, 1f);

                target target = hit.transform.GetComponent<target>();
                if (target != null)
                {
                    target.health -= ShootDamage;
                    Debug.Log(target.health);
                }

                Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal));
            }
            bullets--;
            timer = 3.5f;
        }*/

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