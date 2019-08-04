using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGame : MonoBehaviour
{
    [SerializeField]
    Button pauseButton;

    [SerializeField]
    UIPlayerHUD uiPlayerHUD;

    [SerializeField]
    GameObject pauseDialogPrefab;

    [SerializeField]
    GameObject resultsDialogPrefab;

    public Transform hudContainerTransform;

    public SingleModeController SingleModeController { get; set; }

    private bool isResultsShown = false;

    void Start()
    {
        pauseButton.onClick.AddListener(OnPause);
    }

    private void OnPause()
    {
        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.ButtonAC);

        Game.Instance.Pause(true);
        GameObject uiPauseDialogGO = Instantiate(pauseDialogPrefab, transform);
        uiPauseDialogGO.GetComponent<UIPauseDialog>().UIGame = this;
    }

    public void ShowResults(bool isWin)
    {
        if (isResultsShown)
            return;

        GameObject resultsDialogGO = Instantiate(resultsDialogPrefab, transform);
        UIResultsDialog uiResultsDialog = resultsDialogGO.GetComponent<UIResultsDialog>();
        if (isWin)
            uiResultsDialog.Win();
        else
            uiResultsDialog.Lose();

        isResultsShown = true;
    }

    public UIPlayerHUD UIPlayerHUD
    {
        get { return uiPlayerHUD; }
    }

}
