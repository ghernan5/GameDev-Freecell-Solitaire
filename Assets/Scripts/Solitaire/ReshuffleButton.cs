using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject popupPanel;

    [Header("Settings")]
    private bool useInvertedTheme = false;

    // ----------------- Scene Controls -----------------
    public void StartGame()
    {
        SceneManager.LoadScene("Solitaire");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // ----------------- Theme -----------------
    public void ToggleInvertedTheme()
    {
        useInvertedTheme = !useInvertedTheme;

        CardSprite[] cards = FindObjectsOfType<CardSprite>(true);
        foreach (CardSprite card in cards)
        {
            if (card != null)
                card.SetSkin(useInvertedTheme);
        }
    }

    // ----------------- Popup -----------------
    public void ShowRules()
    {
        if (popupPanel != null)
            popupPanel.SetActive(true);
        else
            Debug.LogWarning("Popup Panel is not assigned in UIManager!");
    }

    public void HideRules()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
        else
            Debug.LogWarning("Popup Panel is not assigned in UIManager!");
    }
}
