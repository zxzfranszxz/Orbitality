using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISinglePlayerModeDialog : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Button playButton;

    [SerializeField]
    UIRangeComponentWithButtons minRange;
    [SerializeField]
    UIRangeComponentWithButtons maxRange;



    private int minEnemies;
    private int maxEnemies;

    void Start()
    {
        minEnemies = SinglePlayerMode.minEnemies;
        maxEnemies = SinglePlayerMode.maxEnemies;

        backButton.onClick.AddListener(OnBackClick);
        playButton.onClick.AddListener(OnPlayClick);

        minRange.OnChangeValueHandler += MinRange_OnChangeValueHandler;
        maxRange.OnChangeValueHandler += MaxRange_OnChangeValueHandler;

        UpdateConponents();
    }

    private void MaxRange_OnChangeValueHandler(int value)
    {
        if (value > SinglePlayerMode.maxEnemies)
            value = SinglePlayerMode.maxEnemies;
        if (value < minEnemies)
            value = minEnemies;

        maxEnemies = value;

        UpdateConponents();
    }

    private void MinRange_OnChangeValueHandler(int value)
    {
        if (value < SinglePlayerMode.minEnemies)
            value = SinglePlayerMode.minEnemies;
        if (value > maxEnemies)
            value = maxEnemies;

        minEnemies = value;

        UpdateConponents();
    }

    private void UpdateConponents()
    {
        minRange.MinValue = SinglePlayerMode.minEnemies;
        minRange.MaxValue = maxEnemies;
        minRange.Value = minEnemies;

        maxRange.MinValue = minEnemies;
        maxRange.MaxValue = SinglePlayerMode.maxEnemies;
        maxRange.Value = maxEnemies;
    }

    
    public void OnPlayClick()
    {
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);

        Game.Instance.GameStarter.StartGame(new SinglePlayerMode(minEnemies, maxEnemies));
    }

    public void OnBackClick()
    {
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);

        Destroy(gameObject);
    }

}
