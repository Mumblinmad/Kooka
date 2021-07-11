using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
   [SerializeField]
   Transform HomePosition;

   [SerializeField]
   Transform PositionA;

   [SerializeField]
   Transform PositionB;

   [SerializeField]
   Transform PositionC;

   [SerializeField]
   Transform PositionD;

    float speedMultiplier;

    Vector3 rightDirection;
    Vector3 downDirection;
    Vector3 leftDirection;      
    Vector3 upDirection;

    Vector2 turnTowards;

    //Enum states will correspond to the transforms of the emptys in the scene
    enum positionState{
        Left,
        Right,
        Up,
        Down,
        Home
    }

   // positionState currentState;

    public void Start(){
        rightDirection = PositionB.position - HomePosition.position;
        downDirection = PositionD.position - HomePosition.position;
        leftDirection = PositionC.position - HomePosition.position;
        upDirection = PositionA.position - HomePosition.position;
    }

   public void OnDodgeRight(){
       Debug.Log("DODGE: right");
        StartCoroutine("Dodge",rightDirection);
   }
   public void OnDodgeLeft(){
        Debug.Log("DODGE: left");
       gameObject.transform.Translate(leftDirection);
   }
   public void OnDodgeUp(){
        Debug.Log("DODGE: up");
       gameObject.transform.Translate(upDirection);
   }
   public void OnDodgeDown(){
        Debug.Log("DODGE: down");
       gameObject.transform.Translate(downDirection);
   }

   public IEnumerator Dodge(Vector3 direction){

       gameObject.transform.Translate(direction);
       yield return new WaitForSeconds(.3f);
        gameObject.transform.Translate(direction*-1);
   }

   public void OnTurn(InputValue inputValue){
       turnTowards = inputValue.Get<Vector2>();
       //TODO: coroutine for turn to have control over the rotation
       float xDirection = turnTowards.x;
       float yDirection = turnTowards.y;

       if(xDirection > 0 ){RotateTowards(rightDirection);}
      // if(xDirection < 0 ){RotateTowards(leftDirection);}
       if(yDirection > 0 ){RotateTowards(upDirection);}
      // if(yDirection < 0 ){RotateTowards(downDirection);}
        
   }

   private void RotateTowards(Vector3 positionOnBoard){
       Vector3 playerAngle = gameObject.transform.forward;
       Vector3 vectorToTarget = positionOnBoard;

       float angleBetween = Vector3.Angle(playerAngle,vectorToTarget);
       Debug.Log(angleBetween.ToString());

       gameObject.transform.Rotate(0,angleBetween,0,Space.Self);

   }

   
}