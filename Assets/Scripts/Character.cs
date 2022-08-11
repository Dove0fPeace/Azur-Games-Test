using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float m_ForwardSpeed;

    [SerializeField] private float m_SideMoveSpeed;

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

        transform.Translate(Vector3.forward * Time.deltaTime * m_ForwardSpeed, Space.World);

        float targetXPosition = Mathf.Lerp(transform.position.x, GetXPosition(), m_SideMoveSpeed * Time.deltaTime);

        transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);
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
