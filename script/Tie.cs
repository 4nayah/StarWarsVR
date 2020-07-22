using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tie : MonoBehaviour
{

    public float movespeed =400f;
    private Vector3 movementForward;
    public Transform target;
    public int life = 4;
    private Renderer show;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      transform.LookAt(target);
      movementForward = new Vector3(movespeed,0,0);
      transform.Translate(Vector3.forward * movespeed *Time.deltaTime);

      if(life <= 0){
        show.GetComponent<Renderer>().enabled = false;
      }
    }

    private void OnTriggerEnter(Collider other)
    {

      if (other.gameObject.name == "Bullet(Clone)")
      {
        life--;

      }

    }
}
