﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y2K.AI
{
    public class FieldOfView : MonoBehaviour
    {
        #region Variables

        [Header("Sight Settings")]
        public float viewRadius = 5f;
        [Range(0, 360)]
        public float viewAngle = 90f;

        [Header("Find Settings")]
        public float delay = 0.2f;

        public LayerMask targetMask;
        public LayerMask obstacleMask;

        private List<Transform> visibleTargets = new List<Transform>();
        private Transform nearestTarget;

        private float distanceToTarget = 0.0f;
        #endregion Variables

        #region Properties

        public List<Transform> VisibleTargets => visibleTargets;
        public Transform NearestTarget => nearestTarget;
        public float DistanceToTarget => distanceToTarget;

        #endregion Properties

        #region Unity Methods
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("FindTargetsWithDelay", delay);
        }

        #endregion Unity Methods

        #region Logic Methods
        IEnumerator FindTargetsWithDelay(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTargets();
            }
        }

        void FindVisibleTargets()
        {
            distanceToTarget = 0.0f;
            nearestTarget = null;
            visibleTargets.Clear();

            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;

                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                    {
                        visibleTargets.Add(target);

                        if (nearestTarget == null || (distanceToTarget > dstToTarget))
                        {
                            nearestTarget = target;
                        }

                        distanceToTarget = dstToTarget;
                    }
                }
            }
        }

        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
        #endregion Logic Methods
    }
}