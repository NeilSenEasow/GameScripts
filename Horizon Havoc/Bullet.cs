using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter(Collision objectWeHit)
    {
        // General collision debug message
        //Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (objectWeHit.collider.tag == "Target")
        {
            Debug.Log("Hit an obstacle!!");
            Destroy(gameObject);
            CreateBulletImpactEffect(objectWeHit);
        }
        if (objectWeHit.collider.tag == "Wall")
        {
            Debug.Log("Hit a wall!!");
            Destroy(gameObject);
            CreateBulletImpactEffect(objectWeHit);

        }
        if (objectWeHit.gameObject.CompareTag("Nebin"))
        {
            Debug.Log("Hit Nebin!!");
            Destroy(gameObject);
        }
        if (objectWeHit.collider.tag == "Rigid")
        {
            Debug.Log("Hit a rigidbody!!");
            Destroy(gameObject);
            CreateBulletImpactEffect(objectWeHit);
        }
    }

    void CreateBulletImpactEffect(Collision objectWeHit)
    {
        ContactPoint contact = objectWeHit.contacts[0];

        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
            );


        hole.transform.SetParent(objectWeHit.gameObject.transform);
    }
}
