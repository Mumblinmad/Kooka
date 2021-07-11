using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject projectileToBeShot;

    [SerializeField]
    private Transform gunDot;
    public int maxShot;

    void Start(){
        StartCoroutine("FireOnTimer");
    }

     public IEnumerator FireOnTimer(){

            int counter = 0;
            while( counter < maxShot){
                FireGun();
                counter += 1;
                yield return new WaitForSeconds(2f);
            }
     }

    public void FireGun(){

        GameObject spawnedProjectile = Instantiate(projectileToBeShot,gunDot.position,Quaternion.identity);

    }
}
