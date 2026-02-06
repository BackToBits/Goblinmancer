using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _roundsText;
    void Start()
    {
        _roundsText.text = "Rounds Survived: " + GameManager.Instance.CurrentRound;
        StartCoroutine(RestartGame());
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}