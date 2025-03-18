using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerController : WeaponController
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

    public void IncreaseAmount()
    {
        projAmnt += 1;
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
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get direction of mouse click
            mousePosition.z = 0; // Ensure the z-coordinate is zero for 2D
            Vector3 direction = (mousePosition - transform.position).normalized;
            spawnedDagger.GetComponent<DaggerBehavior>().DirectionCheck(direction);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
