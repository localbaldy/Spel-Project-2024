using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private AudioSource shootSoundEffect;
    private Transform FirePoint;
    public GameObject bulletPrefab;
    private float shootCooldown = 1.5f;  // Cooldown time in seconds
    private bool canShoot = true;
    private bool ShotgunEquipped = false;
    public Animator animator;
    [SerializeField] private AudioSource ReloadSound;

    void Start()
    {
        FirePoint = GameObject.Find("FirePoint").transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("EquipGun"))
        {
            ShotgunEquipped = true;
            animator.SetBool("GunEquipped", true);
            ReloadSound.Play();
        }
        if (Input.GetButtonDown("UnEquipGun"))
        {
            ShotgunEquipped = false;
            animator.SetBool("GunEquipped", false);
        }
            


        if (Input.GetButtonDown("Fire1") && canShoot && ShotgunEquipped)
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
