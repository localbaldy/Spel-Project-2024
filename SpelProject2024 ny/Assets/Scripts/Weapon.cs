using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    private Transform FirePoint;
    public GameObject bulletPrefab;
    void Start()
    {
        FirePoint = GameObject.Find("FirePoint").transform;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
         
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}