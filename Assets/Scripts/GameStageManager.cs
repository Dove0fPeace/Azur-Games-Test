using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStage
{
    StartGame,
    PlayGame,
    FinishGame
}
public class GameStageManager : MonoBehaviour
{
    [SerializeField] private Character m_Character;
    [SerializeField] private FolowingCamera m_FolowingCamera;
    [SerializeField] private GameObject m_StartUI;
    [SerializeField] private GameObject m_PlayUI;
    [SerializeField] private GameObject m_FinishUI;
    [SerializeField] private GameObject m_ProgressBar;

    private GameStage _currentGameStage;

    private void Start()
    {
        _currentGameStage = GameStage.StartGame;
        m_FolowingCamera.ChangeGameStage(_currentGameStage);
        m_StartUI.SetActive(true);

        Character.OnStartRun += PlayGameStage;
        FinishLine.OnLevelComplete += FinishGameStage;
    }

    private void OnDestroy()
    {
        Character.OnStartRun -= PlayGameStage;
        FinishLine.OnLevelComplete -= FinishGameStage;
    }

    private void PlayGameStage()
    {
        _currentGameStage = GameStage.PlayGame;
        m_FolowingCamera.ChangeGameStage(_currentGameStage);
        m_StartUI.SetActive(false);
        m_ProgressBar.SetActive(true);
    }

    private void FinishGameStage()
    {
        _currentGameStage = GameStage.FinishGame;
        m_FolowingCamera.ChangeGameStage(_currentGameStage);
        m_FinishUI.SetActive(true);
        m_ProgressBar.SetActive(false);
        m_Character.enabled = false;
    }
}
