using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum Posimas
    {
        HealinngSmall,
        HealingBig,
        MagicSmall,
        MagicBig
    }

    [SerializeField] private float speedPlayer = 5f;
    [SerializeField] private float rotationSpeedPlayer = 5f;
    [SerializeField] private float m_playerHealth = 100f;

    public Animator m_playerAnimation;

    [SerializeField] private Posimas m_posimas;
    [SerializeField] private float m_baseHealing;
    [SerializeField] private float m_baseMagic;


    //No supimos todavia como aplicarlo bien.
    private void PosimasMultiplier(Posimas p_posimas)
    {
        switch (p_posimas)
        {
            case Posimas.HealinngSmall:
                m_baseHealing *= 1.5f;
                break;
            case Posimas.HealingBig:
                m_baseHealing *= 2.5f;
                break;
            case Posimas.MagicSmall:
                m_baseMagic *= 1.5f;
                break;
            case Posimas.MagicBig:
                m_baseMagic *= 2.5f;
                break;
        }
    }
   public void MovePlayer()
   {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        var l_moventDir = new Vector3(moveHorizontal, 0, moveVertical);
        l_moventDir.Normalize();

        transform.position += l_moventDir * speedPlayer * Time.deltaTime;
        if (l_moventDir != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(l_moventDir), rotationSpeedPlayer * Time.deltaTime);

        m_playerAnimation.SetFloat("SpeedPlayer", l_moventDir.magnitude * speedPlayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IceBall"))
        {
            TakeDamageEnemy1();
            Destroy(other);
            
        }
    }



    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamageEnemy2();
        }
    }

    public void TakeDamageEnemy1(float p_damage = 15f)
    {
        m_playerHealth -= p_damage;

        if (m_playerHealth < 0)
        {
            m_playerHealth = 0;
        }
    }

    public void TakeDamageEnemy2(float p_damage = 5f)
    {
        m_playerHealth -= p_damage;

        if (m_playerHealth <0)
        {
            m_playerHealth = 0;
        }

    }
    // Update is called once per frame
    void Update()
    {

        MovePlayer();


    }
}
