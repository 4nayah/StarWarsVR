using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    // Start is called before the first frame update

    private float moveHorizontal;
    private float moveVertical;
    private bool RB;
    private bool LB;
    private Rigidbody rb;
    public float movespeed =60f;
    private Vector3 movement;
    public float turnSpeed = 150f;
    public float strafe = 10f;
    private Vector3 moveDirection;
    private float rightTrigger;
    private float startHeight;
    public float gravity;




    void Start()
    {
      rb = GetComponent<Rigidbody>();
      startHeight = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
      moveHorizontal = Input.GetAxis ("J1_MainHorizontal");
      moveVertical = Input.GetAxis ("J1_MainVertical");
      rightTrigger = Input.GetAxis("J1_RTrigger");
      RB = Input.GetButton("J1RB");
      LB = Input.GetButton("J1LB");


      movement = new Vector3(moveVertical,moveHorizontal,0);
      transform.Translate(Vector3.forward * movespeed * rightTrigger *Time.deltaTime);



       if(rightTrigger>0){

         transform.Rotate(movement, turnSpeed * Time.deltaTime);
       }

       if(RB == true){
          transform.Translate(Vector3.right * strafe * Time.deltaTime);
       }
       if(LB == true){
          transform.Translate(Vector3.left * strafe * Time.deltaTime);
       }



      if(Input.GetAxis("J1_RTrigger") > 0)
      {
       movement = new Vector3 ( Input.GetAxis("J1_RTrigger") * movespeed * Time.deltaTime, 0, 0);

        rb.MovePosition (transform.position + movement);
      }
      if(Input.GetAxis("J1_LTrigger") > 0)
      {
        movespeed =(60f / Input.GetAxis("J1_LTrigger")) + 60f;
      }else{
        movespeed =60f;
      }

    }
}
