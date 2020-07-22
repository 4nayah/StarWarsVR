using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

  public float distanceFromObject = 60f;
  public Transform playerObject;
  private float moveHorizontal;
  public Vector3 offset;
  private Vector3 Target;
  private Vector3 desiredPosition;
  private Vector3 smoothedPosition;
  private float smooth = 5.0f;
  void Start()
  {
    moveHorizontal = Input.GetAxis ("J1_MainHorizontal");
  }

  void LateUpdate()
  {

        Vector3 lookOnObject = playerObject.position - transform.position;
        lookOnObject = playerObject.position - transform.position;
        transform.forward = lookOnObject.normalized;
        Vector3 playerLastPosition;
        playerLastPosition = playerObject.position - lookOnObject.normalized * distanceFromObject;
        playerLastPosition.y = playerObject.position.y + distanceFromObject/2;
        // transform.position = playerLastPosition;

        desiredPosition = playerLastPosition;
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
        transform.position = smoothedPosition;


         // Target.Set(moveHorizontal, 0, 0);
         // Quaternion rotation = Quaternion.LookRotation(Target);
         // transform.rotation = rotation;

        // offset = Quaternion.Set(0,0,0,1);


        // transform.rotation = Quaternion.Slerp(transform.rotation, Controller.transform.localRotation * offset2, Time.deltaTime * 2);




    // transform.position = Controller.transform.position + offset;


    // desiredPosition = Ballon.transform.position + offset;
    // smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
    // transform.position = smoothedPosition;

    // transform.rotation = Quaternion.Slerp(transform.rotation, Controller.transform.localRotation * offset2, Time.deltaTime * 2);

    //
    // movement = new Vector3(0,moveHorizontal,0);
    // transform.Rotate(movement, turnSpeed * Time.deltaTime);
  }
}
