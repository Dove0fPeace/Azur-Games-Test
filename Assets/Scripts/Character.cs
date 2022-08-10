using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float m_Speed;

    [SerializeField] private Animator m_Animator;

    [SerializeField] private LayerMask m_Layer;

    private bool _isRunning;

    private Vector3 mouseWorldPosition;

    private bool _runIsStarted;

    public static event Action OnStartRun;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(_runIsStarted == false)
            {
                _runIsStarted = true;
                OnStartRun?.Invoke();
            }
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }

        Move();
        m_Animator.SetBool("isRuning", _isRunning);
    }

    private void OnDisable()
    {
        m_Animator.SetBool("isRuning", false);
    }

    private void Move()
    {
        if(_isRunning == false) return;

        transform.Translate(Vector3.forward * Time.deltaTime * m_Speed, Space.World);

        transform.position = new Vector3(GetXPosition(), transform.position.y, transform.position.z);
    }

    private float GetXPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, m_Layer))
        {
            mouseWorldPosition = raycastHit.point;
        }

        return mouseWorldPosition.x;
    }


}
