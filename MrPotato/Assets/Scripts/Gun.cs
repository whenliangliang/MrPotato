using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float fSpeed = 10;

    PlayerContro playCon;
    // Start is called before the first frame update
    void Start()
    {
        playCon = transform.parent.GetComponent<PlayerContro>();
    }

    // Update is called once per frame
    void Update()
    {
       /* Input.GetKeyDown(KeyCode.Mouse0)*/
        if (Input.GetButtonDown("Fire1")){
            if (playCon.facingRight)
            {
                Rigidbody2D RockectInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                RockectInstance.velocity = new Vector2(fSpeed, 0);
            }
            else
            {
                Rigidbody2D RockectInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                RockectInstance.velocity = new Vector2(-fSpeed, 0);
            }
        }

    }
}
