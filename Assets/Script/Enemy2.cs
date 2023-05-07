using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private Transform vectorPlayer;
    [SerializeField] float rotationSpeedEnemy2 = 20f;
    [SerializeField] float speedEnemy2 = 3f;
    [SerializeField] float distanceEnemyPlayer = 18f;
    [SerializeField] float distanceEnemy2 = 1f;

    public Animator enemy2Animation;

    private void move(Vector3 direction)
    {
        transform.position += direction * (speedEnemy2 * Time.deltaTime);
    }
    private void Enemy2Chase()
    {
       
        var diferenceVector = vectorPlayer.position - transform.position;

        if (distanceEnemy2 < diferenceVector.magnitude)
        {
            transform.LookAt(vectorPlayer);
            move(diferenceVector.normalized);
        }
    }
    // Update is called once per frame
    void Update()
    {
        var distancePlayer = vectorPlayer.position - transform.position;

        if (distanceEnemyPlayer > distancePlayer.magnitude)
        {
            Enemy2Chase();
        }
    }
}
