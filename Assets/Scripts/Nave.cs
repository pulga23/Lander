using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField]
    float maxRelativeVelocity = 10f;

    [SerializeField]
    float maxRotation = 10f;

    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 25f;

    [SerializeField]
    float fuel = 500f;

    private void Update()
    {
        if (fuel > 0f)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(thrustForce * transform.up * Time.deltaTime);
                fuel -= 10*Time.deltaTime;
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
                fuel -= 5*Time.deltaTime;
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
                fuel -= 5*Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("Fiquei sem combustivel");
        }

        Debug.Log(fuel);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            Debug.Log("Aterrei!");
            if(collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) < maxRotation )
            {
                Debug.Log("Mas explodi");
            }

        }
        else
        {
            Debug.Log("Boom!");
        }
    }

}
