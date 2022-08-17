using UnityEngine;

public class UIPlay : MonoBehaviour
{

    public void StartGame()
    {
        GameManager.Instance.MoveToNextLevel();
    }
}
