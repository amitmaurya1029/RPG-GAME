
using System;
using RPG.combat;
using RPG.Movement;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private Mover mover;
        private Fighter fighter;

        private Camera mainCamera;
        RaycastHit hit;

        void Awake()
        {
            mover = GetComponent<Mover>();
            fighter = GetComponent<Fighter>();
        }
        void Start()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            if (InteractWithCombat()) { return; }
            InteractWithMovement();

        }

        private bool InteractWithCombat()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit[] raycastHits = Physics.RaycastAll(RayFromMouse());
                foreach (RaycastHit raycastHit in raycastHits)
                {
                    if (raycastHit.transform.TryGetComponent<CombatTarget>(out CombatTarget combatTarget))
                    {
                        Debug.Log("get the combatTargetComponent : ");
                        fighter.Attack();
                        return true;
                    }
                }

            }
            return false;
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCurser();
            }
        }

        private void MoveToCurser()
        {
            Ray ray = RayFromMouse();

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log(" GET THE INTENDED POSITION FROM MOUSE : " + hit.point);

                mover.MoveTo(hit.point);
            }
            Debug.DrawRay(ray.origin, ray.direction, Color.blue, 2);
        }

        private Ray RayFromMouse()
        {
            return mainCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
    
}
