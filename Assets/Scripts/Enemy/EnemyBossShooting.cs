using UnityEngine;
using System.Collections;

public class EnemyBossShooting : MonoBehaviour {
    [SerializeField] private Transform gunsGroup;
    [SerializeField] private GameObject[] guns;
    [SerializeField] private ParticleSystem[] gunsEffects;
    [SerializeField] private GameObject rocket, indicator;

    [Space]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float shotingCoolDown, shootRate, timeBeforeStartShooting;
    //
    // shotingCoolDown - 
    //
    //
    //
    [SerializeField] private int shootTimes;

    private Animator animator;
    private void Start() {
        animator = GetComponent<Animator>();
        StartCoroutine(ShootingCoolDown());
    }

    private void Update() {
        gunsGroup.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }


    private IEnumerator Shooting() {
        int shootedTimes = 0;
        animator.SetBool("isShooting", true);
        indicator.SetActive(true);

        yield return new WaitForSeconds(timeBeforeStartShooting);

        while (shootedTimes <= shootTimes) {
            shootedTimes++;
            Shoot();
            yield return new WaitForSeconds(shootRate);
        }
        StartCoroutine(ShootingCoolDown());
        
    }
    private IEnumerator ShootingCoolDown() {
        animator.SetBool("isShooting", false);
        indicator.SetActive(false);
        yield return new WaitForSeconds(shotingCoolDown);
        StartCoroutine(Shooting());
    }

    private void Shoot() {
        Vector3 pos;
        Quaternion rot;
        foreach (GameObject gun in guns) {
            pos = gun.transform.position;
            rot = gun.transform.rotation;
            Instantiate(rocket, pos, rot);
        }
        foreach (ParticleSystem particle in gunsEffects) {
            particle.Play();
        }
    }
}
