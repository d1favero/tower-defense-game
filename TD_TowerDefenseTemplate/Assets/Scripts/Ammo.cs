using System;
using UnityEngine;


public class Ammo : MonoBehaviour
{

    [SerializeField]
    AmmoData ammoData;

    Transform targetTransform;


    public void SeekTarget(Transform target)
    {
        targetTransform = target;
    }

    void Update()
    {

        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = targetTransform.position - transform.position;
        float distanceInFrame = ammoData.speed * Time.deltaTime;

        if (dir.magnitude <= distanceInFrame)
        {
            HitTargetEffect();
            return;
        }

        transform.Translate(dir.normalized * distanceInFrame, Space.World);
        transform.LookAt(targetTransform);

    }

    void HitTargetEffect()
    {
        GameObject effectIns = Instantiate(ammoData.hitParticleEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);


        if(ammoData.damageRadius > 0f)
        {
            AreaDamage();
        }
        else
        {
            Damage(targetTransform);
        }

        Destroy(gameObject);
    }

    private void AreaDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, ammoData.damageRadius);
        foreach(Collider col in hitColliders)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Enemy>().TakeDamage(ammoData.damage);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(ammoData.damage);
        }
    }

}
