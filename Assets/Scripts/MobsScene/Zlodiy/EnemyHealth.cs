using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value;
    public Fireball _fireballDamage;

    void Start()
    {
        _fireballDamage = GetComponent<Fireball>();
    }

    void Update()
    {

    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0) Destroy(gameObject);
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
    }
    private void DamageEnemy(Collision collision)
    {
        if (collision.gameObject.tag == "FireBall")
            value -= 20;
        //value -= _fireballDamage.damage;
    }*/

    /*    private void Death()
        {
            if (value <= 0)
            {
                Destroy(gameObject);
            }
        }*/
}
