using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float _speed;
    private Ray ray;
    RaycastHit hit;
    private Vector3 _currentPos;
    private Vector3 _target;
    public LayerMask movementMask;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, movementMask))
            {
                _target = hit.point;
            }
        }
    }

    private void FixedUpdate()
    {
        MovetoPoint();
    }

    private void MovetoPoint()
    {
        _currentPos = rb.transform.position;
        transform.position = Vector3.Lerp(_currentPos, _target, _speed * Time.fixedDeltaTime);
    }
}
