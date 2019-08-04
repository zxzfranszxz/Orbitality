using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIPauseDialog : MonoBehaviour
{
    [SerializeField]
    Button resumeButton;
    [SerializeField]
    Button saveButton;
    [SerializeField]
    Button loadButton;
    [SerializeField]
    Button quitButton;

    public UIGame UIGame { get; set; }

    Game game;
    // Use this for initialization
    void Start()
    {
        game = Game.Instance;

        resumeButton.onClick.AddListener(OnResumeClick);
        saveButton.onClick.AddListener(OnSaveClick);
        loadButton.onClick.AddListener(OnLoadClick);
        quitButton.onClick.AddListener(OnQuitClick);

        loadButton.interactable = game.SaveManager.IsSaveAvaliable;
        saveButton.interactable = UIGame.SingleModeController.PlayerPlanetController.PlanetController.PlanetModel.IsAlive;
    }

    public void OnResumeClick()
    {
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);

        game.Pause(false);
        Destroy(gameObject);
    }

    public void OnSaveClick()
    {
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);

        if (UIGame && UIGame.SingleModeController)
        {
            int playerPlanetId = UIGame.SingleModeController.PlayerPlanetController.PlanetController.PlanetModel.Id;

            game.SaveManager.Save(UIGame.SingleModeController.PlanetList, playerPlanetId);
        }

        OnResumeClick();
    }

    public void OnLoadClick()
    {
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);

        game.Pause(false);
        game.GameStarter.LoadGame();
    }

    public void OnQuitClick()
    {
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);

        game.Pause(false);
        SceneManager.LoadScene("MainMenu");
    }
}
