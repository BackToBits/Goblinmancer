using UnityEngine;

public class Castle : MonoBehaviour
{
    void OnDestroy()
    {
        GameManager.Instance.LoseTheGame();
    }
}