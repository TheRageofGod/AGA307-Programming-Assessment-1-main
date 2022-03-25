using System;

public class GameEvents
{
    public static event Action<Target> OnEnemyHit = null;
    public static event Action<Target> OnEnemyDied = null;
    public static event Action<Difficulty> OnDifficultyChange = null;
    public static event Action<GameState> OnGameStateChange = null;
    public static event Action<int> OnScoreChange = null;
    public static event Action<int> OnListChange = null;

    public static void ReportListChange(int _Enemies)
    {
        OnListChange?.Invoke(_Enemies);
    }
    public static void ReportEnemyHit(Target _enemy)
    {
        OnEnemyHit?.Invoke(_enemy);
    }
    public static void ReportEnemyDied(Target _enemy)
    {
        OnEnemyDied?.Invoke(_enemy);
    }
    public static void ReportDifficultyChange(Difficulty _difficulty)
    {
        OnDifficultyChange?.Invoke(_difficulty);
    }
    public static void ReportGameStateChange(GameState _gameState)
    {
        OnGameStateChange?.Invoke(_gameState);
    }
    public static void ReportScoreChange(int _score)
    {
        OnScoreChange?.Invoke(_score);
    }
}
