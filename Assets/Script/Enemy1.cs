using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] Transform vectorPlayer;
    [SerializeField] Transform shootobject;
    [SerializeField] float rotationSpeedEnemy1 = 20f;
    [SerializeField] float distanceEnemy1 = 18f;


    [SerializeField] private IceBall iceBall;
    [SerializeField] private float timeToShoot = 1f;
    private float curretTimeToShoot;

    public Animator vampireAnimation;



    private void ShootEnemy1()
    {
        Instantiate(iceBall, shootobject.position, transform.rotation);
        curretTimeToShoot = timeToShoot;
    }
        // Update is called once per frame
        void Update()
    {
        var distancePlayer = vectorPlayer.position - transform.position;
        curretTimeToShoot -= Time.deltaTime;

        if (distanceEnemy1 > distancePlayer.magnitude && (curretTimeToShoot <= 0))
        {
            ShootEnemy1();
  
        }
    }
}
