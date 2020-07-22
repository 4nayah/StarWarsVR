using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{

  private float moveHorizontal;
  private float moveVertical;
  public GameObject Controller;
  private Rigidbody rb;
  private Vector3 movement;
  public float turnSpeed = 100f;
  private Vector3 moveDirection;
  private float rightTrigger;
  public Quaternion offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      moveHorizontal = Input.GetAxis ("J1_MainHorizontal");

      movement = new Vector3(- moveHorizontal,0,0);

      transform.Rotate(movement, turnSpeed * Time.deltaTime);


      transform.rotation = Quaternion.Slerp(transform.rotation, Controller.transform.localRotation * offset, Time.deltaTime * 2);
    }
}
