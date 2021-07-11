using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public UserInterfaceManager theInterface;

    [SerializeField]
    float translationSpeed;
    [SerializeField]
    float lifeTime;

    float startFrame;

    void Start(){
        startFrame = Time.frameCount;

        theInterface = GameObject.Find("UIManager").GetComponent<UserInterfaceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(gameObject.transform.right * translationSpeed * Time.deltaTime,Space.World);
        if(Time.frameCount - startFrame > lifeTime * 60) {
            theInterface.SendMessage("incrementScore",1);
            Destroy(gameObject);}
    }

    public void OnColliderEnter(Collision collision){

        Debug.Log("Boom,Pow, Nonsense");
        Destroy(gameObject);

        
    }
}
