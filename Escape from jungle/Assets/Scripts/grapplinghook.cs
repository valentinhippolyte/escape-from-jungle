﻿using System.Collections;
using UnityEngine;

public class grapplinghook : MonoBehaviour
{
    // Création du grapin

    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance=10f;
    public LayerMask mask;

   
    void Start()
    {
        joint = GetComponent<DistanceJoint2D> ();
    }

    
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.G)) {
            targetPos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z=0;

            hit= Physics2D.Raycast(transform.position,targetPos-transform.position,distance,mask);

            if(hit.collider!=null && hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
            {
                joint.enabled=true;
                joint.connectedBody=hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.connectedAnchor=hit.point - new Vector2(hit.collider.transform.position.x,hit.collider.transform.position.y);
                joint.distance= Vector2.Distance(transform.position,hit.point);

            }
        }

        if(Input.GetKeyUp (KeyCode.G)) {
            joint.enabled=false;
        }
    }
}
