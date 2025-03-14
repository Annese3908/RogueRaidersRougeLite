using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntShotController : AntWeaponController
{
    //pull data from weapon Data
    protected int projAmnt;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    void Awake(){
     projAmnt = weaponData.ProjectileAmnt;
    }

    // Update is called once per frame
    protected override void Attack()
    {

        base.Attack();
        StartCoroutine(ShootDagger());
       
    }
    IEnumerator ShootDagger(){
        for(int i = 0; i < projAmnt; i++){
            GameObject spawnedDagger = Instantiate(weaponData.Prefab);
            spawnedDagger.transform.position = transform.position; // assign position of dagger to be same as player
            spawnedDagger.GetComponent<DaggerBehavior>().DirectionCheck(em.transform.position);
            yield return new WaitForSeconds(0.4f);
        }
    }
}

