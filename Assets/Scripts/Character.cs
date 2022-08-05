using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float m_Speed;

    [SerializeField] private Animator m_Animator;

    [SerializeField] private LayerMask m_Layer;

    private bool _isRunning;

    private Vector3 mouseWorldPosition;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }

        Move();

        m_Animator.SetBool("isRuning", _isRunning);
    }

    private void Move()
    {
        if(_isRunning == false) return;

        transform.Translate(Vector3.forward * Time.deltaTime * m_Speed, Space.World);

        //float f = GetYPosition();

        transform.position = new Vector3(GetXPosition(), transform.position.y, transform.position.z);
        //transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    private float GetXPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, m_Layer))
        {
            mouseWorldPosition = raycastHit.point;
        }
       
        print(mouseWorldPosition);

        return mouseWorldPosition.x;
    }


}
