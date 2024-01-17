using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private AudioSource shootSoundEffect;
    private Transform FirePoint;
    public GameObject bulletPrefab;
    private float shootCooldown = 1.5f;  // Cooldown time in seconds
    private bool canShoot = true;
    public Animator animator;

    void Start()
    {
        FirePoint = GameObject.Find("FirePoint").transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            animator.SetTrigger("Shoot");
            Shoot();
            shootSoundEffect.Play();
            StartCoroutine(ShootCooldown());
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
