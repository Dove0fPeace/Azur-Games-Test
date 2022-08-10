using UnityEngine;

public class FolowingCamera : MonoBehaviour
{
    [SerializeField] private Vector3 m_StartOffset;
    [SerializeField] private Vector3 m_StartRotation;

    [Space(10)]
    [SerializeField] private Vector3 m_PlayOffset;
    [SerializeField] private Vector3 m_PlayRotation;

    [Space(10)]
    [SerializeField] private Vector3 m_FinishOffset;
    [SerializeField] private Vector3 m_FinishRotation;
    
    [Space(10)]
    [SerializeField] private float m_OffsetChangeSpeed;
    [SerializeField] private float m_RotationChangeSpeed;

    [SerializeField] private Transform m_TargetTransform;

    private Vector3 targetPosition;

    private Vector3 _currentOffset;
    private Vector3 _currentRotation;

    [SerializeField] private bool _finish = false;

    private void Update()
    {
        targetPosition = new Vector3(m_TargetTransform.position.x + _currentOffset.x, m_TargetTransform.position.y + _currentOffset.y, m_TargetTransform.position.z + _currentOffset.z);

        if(_finish == false)
        {
            targetPosition.x = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, m_OffsetChangeSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_currentRotation), m_RotationChangeSpeed * Time.deltaTime);
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
                _currentOffset = m_FinishOffset;
                _currentRotation = m_FinishRotation;
                _finish = true;
                break;
        }
    }
}
