using UnityEngine;
using System.Collections;
using System;

namespace Tag.Pratik
{
    public class PlayerMovement : MonoBehaviour
    {
        #region PUBLIC_VARS
        public GameObject targetObject;
        #endregion

        #region PRIVATE_VARS
        private Vector3 targetObjectNextPosition;
        private Vector3 worldMousePosition;
        private Vector3 direction;
        private RaycastHit hit;
        #endregion
        #region UNITY_CALLBACKS

        void Start()
        {
            targetObjectNextPosition = targetObject.transform.position;
        }
        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
                direction = worldMousePosition - Camera.main.transform.position;
                if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
                {
                    if (hit.collider.gameObject.name == "GroundPlan")
                    {
                        targetObjectNextPosition = hit.point;
                    }
                }
            }
            SetPlayerPosition();

        }
        #endregion

        #region PUBLIC_FUNCTIONS
        private void SetPlayerPosition()
        {
            targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, targetObjectNextPosition, 5f * Time.deltaTime);
            targetObject.transform.LookAt(targetObjectNextPosition);
        }
        #endregion
    }
}