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

    public Transform hudContainerTransform;

    public SingleModeController SingleModeController { get; set; }


    void Start()
    {
        pauseButton.onClick.AddListener(OnPause);
    }

    private void OnPause()
    {
        Game.Instance.Pause(true);
        GameObject uiPauseDialogGO = Instantiate(pauseDialogPrefab, transform);
        uiPauseDialogGO.GetComponent<UIPauseDialog>().UIGame = this;
    }

    public UIPlayerHUD UIPlayerHUD
    {
        get { return uiPlayerHUD; }
    }

}
