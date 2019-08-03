using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGame : MonoBehaviour
{
    [SerializeField]
    Button pauseButton;

    [SerializeField]
    UIPlayerHUD uiPlayerHUD;

    public Transform hudContainerTransform;

    public SingleModeController SingleModeController { get; set; }


    void Start()
    {
        pauseButton.onClick.AddListener(OnPause);
    }

    private void OnPause()
    {
        Game.Instance.Pause(true);
    }

    public UIPlayerHUD UIPlayerHUD
    {
        get { return uiPlayerHUD; }
    }

}
