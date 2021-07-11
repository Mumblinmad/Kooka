using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailState : MonoBehaviour
{
    //At the time of coding, Projectile damage was 5;
    [SerializeField]
    float hitPoints;

    void Start(){
        if(hitPoints == 0)hitPoints = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPoints<=0){Debug.Log("Destroyed by update!");Destroy(gameObject);}
    }

    public void OnTriggerEnter(){

        Debug.Log("YOU LOSE!");

    }

    public void ApplyDamage(float damage){

        float healthLeft = hitPoints - damage;

        //TODO: trigger failure screen/ retry
        if(healthLeft>=0){Destroy(gameObject);}
        else{
            hitPoints = hitPoints - damage;
        }
    }
}
