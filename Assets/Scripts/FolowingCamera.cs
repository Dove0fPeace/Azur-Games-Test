using UnityEngine;

public class FolowingCamera : MonoBehaviour
{
    [SerializeField] private Vector3 m_StartOffset;
    [SerializeField] private Vector3 m_StartRotation;

    [Space(10)]
    [SerializeField] private Vector3 m_PlayOffset;
    [SerializeField] private Vector3 m_PlayRotation;

    [Space(10)]
    [SerializeField] private Transform m_FinishTargetTransform;
    
    [Space(10)]
    [SerializeField] private float m_OffsetChangeSpeed;
    [SerializeField] private float m_RotationChangeSpeed;

    [SerializeField] private Transform m_TargetTransform;

    private Vector3 targetPosition;

    private Vector3 _currentOffset;
    private Vector3 _currentRotation;

    private bool _finish = false;

    private void Update()
    {
        if (_finish)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_FinishTargetTransform.position, m_OffsetChangeSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_FinishTargetTransform.rotation, m_RotationChangeSpeed * Time.deltaTime);
        }
        else
        {
            targetPosition = new Vector3(0, m_TargetTransform.position.y + _currentOffset.y, m_TargetTransform.position.z + _currentOffset.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, m_OffsetChangeSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_currentRotation), m_RotationChangeSpeed * Time.deltaTime);
        }
    }

    public void ChangeGameStage(GameStage stage)
    {
        switch(stage)
        {
            case GameStage.StartGame:
                _currentOffset = m_StartOffset;
                _currentRotation = m_StartRotation;
                break;

            case GameStage.PlayGame:
                _currentOffset = m_PlayOffset;
                _currentRotation = m_PlayRotation;
                break;

            case GameStage.FinishGame:
                _finish = true;
                break;
        }
    }
}
