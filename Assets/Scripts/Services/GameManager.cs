using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Lives { get => _lives; }
    public int Coins { get => _coins; }
    public static GameManager Instance { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    public int _currentLevelIndex;

    public void MoveToNextLevel()
    {
        _currentLevelIndex = IncrementAndCheckForLastScene(_currentLevelIndex);
        SceneManager.LoadScene(_currentLevelIndex);
    }

    private int IncrementAndCheckForLastScene(int currentLevelIndex)
    {
        var nextScene = currentLevelIndex + 1;
        var indexOfLastScene = SceneManager.sceneCountInBuildSettings;
        nextScene %= indexOfLastScene;
        return nextScene;
    }

    public void AddCoin()
    {
        _coins++;
        OnCoinsChanged?.Invoke(_coins);
    }

    public void KillPlayer()
    {
        _lives--;

        OnLivesChanged?.Invoke(_lives);
        if (_lives == 0)
            RestartGame();
        else
            TransportPlayerToCheckpoint();
    }

    private static void TransportPlayerToCheckpoint()
    {
        var checkpoint = FindObjectOfType<CheckpointManager>().GetLastCheckpointThatWasPassed();
        var player = FindObjectOfType<PlayerMovement>();
        player.transform.position = checkpoint.transform.position;
    }

    private void Awake()
    {
        if (!(Instance is null))
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ResetGameValues();
        }
    }

    private void RestartGame()
    {
        ResetGameValues();
        SceneManager.LoadScene(0);
    }

    private void ResetGameValues()
    {
        _coins = 0;
        _lives = 3;
        _currentLevelIndex = 0;
    }

    private int _lives;
    private int _coins;
}
