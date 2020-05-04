using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject[] waypoints;
 
    public float speed;

    private int weather;

    bool changeDirection;
    NavMeshAgent myAgent;
    float health = 100;
    Transform playerPos;
    public float power = 10;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;
    public GameObject spawnPoint;

    Transform wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8, wp9;
    int waypointLocs = 7;

    float timerSpeed = 1;
    float elapsed;
    bool behindCover;
    ParticleSystem deathEffect;

    GameObject mageModel;
    // Start is called before the first frame update
    void Start()
    {
        changeDirection = false;
        myAgent = GetComponent<NavMeshAgent>();
        wp1 = GameObject.Find("wp1").GetComponent<Transform>();
        wp2 = GameObject.Find("wp2").GetComponent<Transform>();
        wp3 = GameObject.Find("wp3").GetComponent<Transform>();
        wp4 = GameObject.Find("wp4").GetComponent<Transform>();
        wp5 = GameObject.Find("wp5").GetComponent<Transform>();
        wp6 = GameObject.Find("wp6").GetComponent<Transform>();
        wp7 = GameObject.Find("wp7").GetComponent<Transform>();
        wp8 = GameObject.Find("wp8").GetComponent<Transform>();
        wp9 = GameObject.Find("wp9").GetComponent<Transform>();
        mageModel = GameObject.Find("poseTest").GetComponent<GameObject>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        InvokeRepeating("shoot", 2.0f, 4f);
        deathEffect = GameObject.Find("DeathParticle").GetComponent<ParticleSystem>();

        weather = 0;
    }

    // Update is called once per frame
    void Update()
    {

        elapsed += Time.deltaTime;
        if(elapsed >= timerSpeed)
        {
            elapsed = 0f;
            

        }


        transform.LookAt(playerPos.position);
        if (changeDirection == false)
        {
           
            myAgent.SetDestination(wp1.position);
        }

        if (health <= 0)
        {
          ;
            StartCoroutine(startDeath());

            deathEffect.Play();
        }
        weather = GameObject.Find("Player").GetComponent<WeatherMan>().getMode();
        //Debug.Log("enemy sees mode: " + weather);
    }

    private void OnTriggerEnter(Collider other)
    {
        int modf;
        int modi;
        int modl;
        switch(weather)
        {

            case 1://rain
                modf = -5;
                modi = 0;
                modl = 10;
                break;
            case 2://snow
                modf = 0;
                modi = 10;
                modl = -5;
                break;
            case 3://wind
                modf = -5;
                modi = 10;
                modl = 0;
                break;

            default://sunny
                modf = 10;
                modi = -5;
                modl = 0;
                break;                
        }
        //Debug.Log("modifyer vars " + modf + " " + modi + " " + modl);

        //Enemy Taking Damage
        if(other.tag == "fire")
        {
            health -= 10 + modf;
            Debug.Log("Damage taken");
        }
        else if(other.tag == "ice")
        {
            health -= 10 + modi;
        }
        else if(other.tag == "lightning")
        {
            health -= 10 + modl;
        }

       

        //Enemy Movement between waypoints
        waypointLocs = Random.Range(1, 9);
        if (other.tag == "wp1")
        {
            behindCover = false;
            StartCoroutine(StopMove());
            changeDirection = true;
            switch (waypointLocs)
            {
                case 1:
                    myAgent.SetDestination(wp2.position);
                    break;
                case 2:
                    myAgent.SetDestination(wp3.position);
                    break;
                case 3:
                    myAgent.SetDestination(wp4.position);
                    break;
                case 4:
                    myAgent.SetDestination(wp5.position);
                    break;
                case 5:
                    myAgent.SetDestination(wp6.position);
                    break;
                case 6:
                    myAgent.SetDestination(wp7.position);
                    break;
                case 7:
                    myAgent.SetDestination(wp8.position);
                    break;
                case 8:
                    myAgent.SetDestination(wp9.position);
                    break;
            }
        }
        else if (other.tag == "wp2")
        {
            behindCover = true;
            StartCoroutine(StopMove());
            changeDirection = true;
            switch (waypointLocs)
            {
                case 1:
                    myAgent.SetDestination(wp3.position);
                    break;
                case 2:
                    myAgent.SetDestination(wp4.position);
                    break;
                case 3:
                    myAgent.SetDestination(wp5.position);
                    break;
                case 4:
                    myAgent.SetDestination(wp6.position);
                    break;
                case 5:
                    myAgent.SetDestination(wp7.position);
                    break;
                case 6:
                    myAgent.SetDestination(wp8.position);
                    break;
                case 7:
                    myAgent.SetDestination(wp9.position);
                    break;
                case 8:
                    myAgent.SetDestination(wp1.position);
                    break;
            }           
        }
        else if (other.tag == "wp3")
        {
            behindCover = false;
            StartCoroutine(StopMove());
            changeDirection = true;
            switch (waypointLocs)
            {
                case 1:
                    myAgent.SetDestination(wp4.position);
                    break;
                case 2:
                    myAgent.SetDestination(wp5.position);
                    break;
                case 3:
                    myAgent.SetDestination(wp6.position);

                    break;
                case 4:
                    myAgent.SetDestination(wp7.position);
                    break;
                case 5:
                    myAgent.SetDestination(wp8.position);
                    break;
                case 6:
                    myAgent.SetDestination(wp9.position);
                    break;
                case 7:
                    myAgent.SetDestination(wp1.position);
                    break;
                case 8:
                    myAgent.SetDestination(wp2.position);
                    break;
            }
        }
        else if (other.tag == "wp4")
        {
            behindCover = false;
            StartCoroutine(StopMove());
            changeDirection = true;
            switch (waypointLocs)
            {
                case 1:
                    myAgent.SetDestination(wp5.position);
                    break;
                case 2:
                    myAgent.SetDestination(wp6.position);
                    break;
                case 3:
                    myAgent.SetDestination(wp7.position);

                    break;
                case 4:
                    myAgent.SetDestination(wp8.position);
                    break;
                case 5:
                    myAgent.SetDestination(wp9.position);
                    break;
                case 6:
                    myAgent.SetDestination(wp1.position);
                    break;
                case 7:
                    myAgent.SetDestination(wp2.position);
                    break;
                case 8:
                    myAgent.SetDestination(wp3.position);
                    break;
            }
        }
        else if (other.tag == "wp5")
        {
            behindCover = false;
            StartCoroutine(StopMove());
            changeDirection = true;
            switch (waypointLocs)
            {
                case 1:
                    myAgent.SetDestination(wp6.position);
                    break;
                case 2:
                    myAgent.SetDestination(wp7.position);
                    break;
                case 3:
                    myAgent.SetDestination(wp8.position);
                    break;
                case 4:
                    myAgent.SetDestination(wp9.position);
                    break;
                case 5:
                    myAgent.SetDestination(wp1.position);
                    break;
                case 6:
                    myAgent.SetDestination(wp2.position);
                    break;
                case 7:
                    myAgent.SetDestination(wp3.position);
                    break;
                case 8:
                    myAgent.SetDestination(wp4.position);
                    break;
            }
        }
        else if (other.tag == "wp6")
        {
            behindCover = false;
            StartCoroutine(StopMove());
            changeDirection = true;
            switch (waypointLocs)
            {
                case 1:
                    myAgent.SetDestination(wp7.position);
                    break;
                case 2:
                    myAgent.SetDestination(wp8.position);
                    break;
                case 3:
                    myAgent.SetDestination(wp9.position);

                    break;
                case 4:
                    myAgent.SetDestination(wp1.position);
                    break;
                case 5:
                    myAgent.SetDestination(wp2.position);
                    break;
                case 6:
                    myAgent.SetDestination(wp3.position);
                    break;
                case 7:
                    myAgent.SetDestination(wp4.position);
                    break;
                case 8:
                    myAgent.SetDestination(wp5.position);
                    break;
            }
        }
        else if (other.tag == "wp7")
        {
            behindCover = true;
            StartCoroutine(StopMove());
            changeDirection = true;
            switch (waypointLocs)
            {
                case 1:
                    myAgent.SetDestination(wp8.position);
                    break;
                case 2:
                    myAgent.SetDestination(wp9.position);
                    break;
                case 3:
                    myAgent.SetDestination(wp1.position);

                    break;
                case 4:
                    myAgent.SetDestination(wp2.position);
                    break;
                case 5:
                    myAgent.SetDestination(wp3.position);
                    break;
                case 6:
                    myAgent.SetDestination(wp4.position);
                    break;
                case 7:
                    myAgent.SetDestination(wp5.position);
                    break;
                case 8:
                    myAgent.SetDestination(wp6.position);
                    break;
            }
        }
        else if (other.tag == "wp8")
        {
            behindCover = false;
            StartCoroutine(StopMove());
            changeDirection = true;
            switch (waypointLocs)
            {
                case 1:
                    myAgent.SetDestination(wp9.position);
                    break;
                case 2:
                    myAgent.SetDestination(wp1.position);
                    break;
                case 3:
                    myAgent.SetDestination(wp2.position);

                    break;
                case 4:
                    myAgent.SetDestination(wp3.position);
                    break;
                case 5:
                    myAgent.SetDestination(wp4.position);
                    break;
                case 6:
                    myAgent.SetDestination(wp5.position);
                    break;
                case 7:
                    myAgent.SetDestination(wp6.position);
                    break;
                case 8:
                    myAgent.SetDestination(wp7.position);
                    break;
            }
        }
        else if (other.tag == "wp9")
        {
            behindCover = false;
            StartCoroutine(StopMove());
            changeDirection = true;
            switch (waypointLocs)
            {
                case 1:
                    myAgent.SetDestination(wp1.position);
                    break;
                case 2:
                    myAgent.SetDestination(wp2.position);
                    break;
                case 3:
                    myAgent.SetDestination(wp3.position);

                    break;
                case 4:
                    myAgent.SetDestination(wp4.position);
                    break;
                case 5:
                    myAgent.SetDestination(wp5.position);
                    break;
                case 6:
                    myAgent.SetDestination(wp6.position);
                    break;
                case 7:
                    myAgent.SetDestination(wp7.position);
                    break;
                case 8:
                    myAgent.SetDestination(wp8.position);
                    break;
            }
        }

    }
    IEnumerator StopMove()
    {
        myAgent.speed = 0;
        int waitTime = Random.Range(1, 3);
        yield return new WaitForSeconds(waitTime);
        StartMove();

    }

    void StartMove()
    {
        myAgent.speed = 10;
    }

    IEnumerator startDeath()
    {
        myAgent.speed = 0;
        
        yield return new WaitForSeconds(3);
        die();

    }

    void die()
    {
        Destroy(gameObject);
    }

    public void speedBoost()
    {
        myAgent.speed = 200;
    }



    public void shoot()
    {
        if (behindCover == false)
        {
            GameObject g = Instantiate(projectilePrefab, spawnPoint.transform.position, transform.rotation) as GameObject;
            Rigidbody body = g.GetComponent<Rigidbody>();
            body.AddForce(transform.forward.normalized * power, ForceMode.Impulse);
        }
     
    }

}


