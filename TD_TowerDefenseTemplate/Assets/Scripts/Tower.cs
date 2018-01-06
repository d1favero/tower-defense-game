using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    public TowerData towerData;
    [SerializeField]
    Transform transformRotateToTarget;
    [SerializeField]
    Transform[] firePositions;

    [Header("Runtime Info")]
    [SerializeField]
    Transform target;
    [SerializeField]
    Enemy targetEnemy;

    float countdown = 0f;


    void Start()
    {
        InvokeRepeating("SearchTarget", 0f, 0.5f);
    }


    void Update()
    {
        if (target == null)
            return;

        LockOnTarget();

        if (countdown <= 0f)
        {
            Fire();
            countdown = 1f / towerData.fireRate;
        }

        countdown -= Time.deltaTime;
    }

    private void SearchTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(towerData.enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= towerData.range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }


    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transformRotateToTarget.rotation, lookRotation, Time.deltaTime * towerData.turnSpeed).eulerAngles;
        transformRotateToTarget.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Fire()
    {
        GameObject bulletGO;
        Ammo bullet;

        for (int i = 0; i < firePositions.Length; i++)
        {
            bulletGO = (GameObject)Instantiate(towerData.ammoPrefab, firePositions[i].position, firePositions[i].rotation);
            bullet = bulletGO.GetComponent<Ammo>();

            if (bullet != null)
                bullet.SeekTarget(target);
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, towerData.range);
    }
}
