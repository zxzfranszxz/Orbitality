using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIResultsDialog : MonoBehaviour
{
    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private Text resultText;

    private void Start()
    {
        continueButton.onClick.AddListener(OnContinueClick);
    }

    private void OnContinueClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Win()
    {
        resultText.text = "YOU WIN";
        resultText.color = Color.green;
    }

    public void Lose()
    {
        resultText.text = "YOU LOSE";
        resultText.color = Color.red;
    }


}
