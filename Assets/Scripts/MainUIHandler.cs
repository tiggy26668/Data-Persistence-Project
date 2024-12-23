using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.Instance.GetBestName() != "")
        {
            highScoreText.SetText("Best Score: " + GameManager.Instance.GetBestName() + " : " + GameManager.Instance.GetBestScore());
        }
    }
}
