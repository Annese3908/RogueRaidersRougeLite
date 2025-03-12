using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerController : WeaponController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedDagger = Instantiate(weaponData.Prefab);
        spawnedDagger.transform.position = transform.position; // assign position of dagger to be same as player
        spawnedDagger.GetComponent<DaggerBehavior>().DirectionCheck(pm.lastMovedVector);
    }
}
