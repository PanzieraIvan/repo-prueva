using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [SerializeField] private float speedIceBall;
    [SerializeField] private float initialTime = 3f;
    private float currentTime;

    private void Awake()
    {
        currentTime = initialTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            Destroy(gameObject);
        }
        transform.position += speedIceBall * Time.deltaTime * transform.forward;
    }
}
