using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform target;
    NavMeshAgent agent;
    private Animator animator;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = transform.GetChild(0).GetComponent<Animator>();
            

    }


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            CreatRay();
        }

        TrigerAnimation();

    }


    private void CreatRay()
    {
        RaycastHit hit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.Log(" GET THE INTENDED POSITION FROM MOUSE : " + hit.point);

            if (agent != null)
            {
                //agent.destination = hit.point;
                MoveTo(hit.point);
            }
        }


        Debug.DrawRay(ray.origin, ray.direction, Color.blue, 2);
    }


    public void MoveTo(Vector3 destination)
    {
         agent.destination = destination;
    }

    private void TrigerAnimation()
    {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        animator.SetFloat("Velocity", localVelocity.z);

        Debug.Log("player agent velocity : " + velocity);

    }


}
