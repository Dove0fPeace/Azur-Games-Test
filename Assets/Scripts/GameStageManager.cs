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
    }

    private void FinishGameStage()
    {
        _currentGameStage = GameStage.FinishGame;
        m_FolowingCamera.ChangeGameStage(_currentGameStage);
        m_FinishUI.SetActive(true);
        m_Character.enabled = false;
    }
}
