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
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);
        Instantiate(singlePlayerDialogPrefab, transform);
    }

    public void OnLoadClick()
    {
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);
        Game.Instance.GameStarter.LoadGame();
    }

    public void OnQuitClick()
    {
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);
        Game.Instance.Quit();
    }
}
