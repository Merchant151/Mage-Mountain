using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject[] waypoints;
 
    public float speed;


    bool changeDirection;
    NavMeshAgent myAgent;
    float health = 100;

    Transform wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8, wp9;
    int waypointLocs = 7;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (changeDirection == false)
        {
            transform.LookAt(wp1.position);
            myAgent.SetDestination(wp1.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (health <= 0)
        {
            
        }
        waypointLocs = Random.Range(1, 9);
        if (other.tag == "wp1")
        {
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
}


