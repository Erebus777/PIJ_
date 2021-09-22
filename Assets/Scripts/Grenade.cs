using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    //Variables;
    public GameObject explosionEffect;
    public float delay = 3f;
    public float explosionForce = 10f;
    public float radius = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", delay);
    }

    // Update is called once per frame
    void Update()
    {

    }


    //Method tha make the grenade explode;
    private void Explode()
    {
        //Checking nearby colliders;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        //Applying them a force;
        foreach (Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();

            if (rig != null)
                rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
        }

        //Explosion Effect;
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemySlime enemySlime;

        if (collision.transform.tag == "Enemy")
        {
            enemySlime = collision.transform.GetComponent<EnemySlime>();
            enemySlime.health--;
            Destroy(this.gameObject);
        }
    }
}
