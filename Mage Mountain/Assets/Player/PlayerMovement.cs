using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 velocity;
    public float gravity = -9.81f;
    public CharacterController controller;
    public float speed = 12f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;


    public GameObject cannonBallPrefab;
    public GameObject spawnPoint;
    public float power;
    float rotateSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))  
        {

            
            shoot(power);
            /*
            //int i = Random.Range(0, bulletPrefab.Length); for random shooting snowmen

            //Created a copy of a gameobject
            GameObject g = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //got a component of a game object
            Rigidbody r = g.GetComponent<Rigidbody>();
            // set a propert of that component
            r.velocity = gameObject.transform.forward * 10 + Vector3.up * 10;

            r.AddForce(gameObject.transform.forward * projectileSpeed);

          //  g.transform.position = transform.position;
          */

        }

    }

    public Rigidbody shoot(float power)
    {
        GameObject g = Instantiate(cannonBallPrefab, spawnPoint.transform.position, transform.rotation) as GameObject;
        Rigidbody body = g.GetComponent<Rigidbody>();
        body.AddForce(transform.forward.normalized * power, ForceMode.Impulse);
        Destroy(g, 2.5f);
        
        return body;
    }


}
