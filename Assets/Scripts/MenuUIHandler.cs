using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameTextInput;
    [SerializeField] private TextMeshProUGUI nameText;

    void Start()
    {
        SetBest();
        nameTextInput.SetTextWithoutNotify(GameManager.Instance.GetName());
    }

    public void StartButtonClick()
    {
        UpdateName();
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClick()
    {
        UpdateName();
        GameManager.Instance.Save();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void UpdateName()
    {
        GameManager.Instance.SetName(nameTextInput.text != "" ? nameTextInput.text : "N/A");
    }
    
    void SetBest()
    {
        if(GameManager.Instance.GetBestName() != "")
        {
            nameText.SetText("Best Score : " + GameManager.Instance.GetBestName() + " : " + GameManager.Instance.GetBestScore());
        }
    }
}
