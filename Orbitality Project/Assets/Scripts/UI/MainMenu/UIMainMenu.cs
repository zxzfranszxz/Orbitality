using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button loadButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    GameObject singlePlayerDialogPrefab;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayClick);
        loadButton.onClick.AddListener(OnLoadClick);
        quitButton.onClick.AddListener(OnQuitClick);

        loadButton.interactable = Game.Instance.SaveManager.IsSaveAvaliable;
    }

    public void OnPlayClick()
    {
        ClickSound.Click();
        Instantiate(singlePlayerDialogPrefab, transform);
    }

    public void OnLoadClick()
    {
        ClickSound.Click();
        Game.Instance.GameStarter.LoadGame();
    }

    public void OnQuitClick()
    {
        ClickSound.Click();
        Game.Instance.Quit();
    }
}
