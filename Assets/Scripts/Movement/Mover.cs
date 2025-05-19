using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform target;
        NavMeshAgent agent;
        private Animator animator;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = transform.GetChild(0).GetComponent<Animator>();
        }

        void Update()
        {
            TrigerAnimation();
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

}

