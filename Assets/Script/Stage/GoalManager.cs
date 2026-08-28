using UnityEngine;
using System;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameObject clearTextUI;

    private void OnEnable()
    {
        GoalArea.OnGoalReached += HandleGoal;
    }

    private void OnDisable()
    {
        GoalArea.OnGoalReached -= HandleGoal;
    }

    private void HandleGoal()
    {
        // ステージクリアUI表示
        clearTextUI.SetActive(true);

        // タイマー停止
        

        // スコア計算
        


        // リザルト保存

        // シーン遷移
        ScreenManager.Instance.ChangeScene(ScreenManager.SceneType.Result);
    }
}
