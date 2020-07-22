using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xwing : MonoBehaviour
{
  private float moveHorizontal;
  private float moveVertical;
  private float moveSecHorizontal;
  private float moveSecVertical;
  private bool RB;
  private bool LB;
  private Rigidbody rb;
  public GameObject Gun;
  public GameObject Gun2;
  public Vector3 offset;
  public float movespeed =120f;
  public float movespeedmax =600f;
  private Vector3 movementForward;
  private Vector3 movementTang;
  private Vector3 movementRoul;
  private Vector3 movementLace;
  public float turnSpeedRoul = 150f;
  public float turnSpeedTang = 30f;
  public float turnSpeedLace = 5f;
  public float strafe = 0.3f;
  private Vector3 moveDirection;
  private float rightTrigger;
  private float startHeight;
  public float gravity;
  private float lacetdroit;
  private float lacetgauche;
  public GameObject bulletPrefab;
  private float bulletSpeed = 15f;
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
      moveSecHorizontal = Input.GetAxis ("J1_SecHorizontal");
      moveSecVertical = Input.GetAxis ("J1_SecVertical");
      rightTrigger = Input.GetAxis("J1_RTrigger");
      RB = Input.GetButton("J1RB");
      LB = Input.GetButton("J1LB");



      movementForward = new Vector3(-moveVertical,0,0);
      transform.Translate(Vector3.forward * movespeed *Time.deltaTime);

      moveHorizontal = Input.GetAxis ("J1_MainHorizontal");

      movementTang = new Vector3(moveVertical,0,0);
      transform.Rotate(movementTang, turnSpeedTang * Time.deltaTime);

      movementRoul = new Vector3(0,0,moveHorizontal);
      transform.Rotate(-movementRoul, turnSpeedRoul * Time.deltaTime);




      if(movespeed>movespeedmax){
        movespeed =movespeedmax;
      }else if(movespeed<20f){
        movespeed=20f;
      }


      if(Input.GetAxis("J1_RTrigger") > 0)
      {
       movespeed++;
      }

      if(Input.GetButtonDown("J1_A_Button"))
      {

        var bullet = (GameObject)Instantiate(bulletPrefab,Gun.transform.position + offset,transform.rotation);
        bullet = (GameObject)Instantiate(bulletPrefab,Gun2.transform.position + offset,transform.rotation);

        bullet.tag = "bullet";
        // bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 2000f;
        // movementForward = new Vector3(-moveVertical,0,0);
        // bullet.transform.Translate(Vector3.forward * movespeed*10 *Time.deltaTime *-1);
       // bullet.tag = "Bullet";
       // bullet.name = "C1Bullet";
       Destroy(bullet, 2.0f);
      }



      offset = new Vector3(moveSecHorizontal*10,moveSecVertical*10,0);

      Debug.Log(offset);

      Gun.transform.Rotate(offset, movespeed * Time.deltaTime);

      if(Input.GetAxis("J1_LTrigger") > 0)
      {
       movespeed--;
      }

      if(RB == true){
        lacetdroit=-1;
      }else{
        lacetdroit=0;
      }
      if(LB == true){
        lacetgauche=-1;
      }else{
        lacetgauche=0;
      }
      movementLace = new Vector3(0,-lacetdroit * strafe,0);
      transform.Rotate(movementLace, turnSpeedLace * Time.deltaTime);
      movementLace = new Vector3(0,-lacetgauche * strafe,0);
      transform.Rotate(-movementLace, turnSpeedLace * Time.deltaTime);


    }



}
