using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform target;
    NavMeshAgent agent;

    [SerializeField] private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
             
    }

    
    void Update()
    {
       


         if (Input.GetMouseButtonDown(0))
         {
            CreatRay();
         }

         
    }


    private void CreatRay()
    {
         RaycastHit hit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.Log(" GET THE INTENDED POSITION FROM MOUSE : " +  hit.point);

             if (agent != null)
            {
                agent.destination = hit.point;
            }
        }


        Debug.DrawRay(ray.origin, ray.direction, Color.blue, 2 );
    }




}
