using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;
    private IHasProgress hasProgress;
    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if (hasProgress == null)
        {
            Debug.LogError(hasProgressGameObject + "接口对象为空，拖入的物品为空或者不带进度条对象");
        }


        hasProgress.OnProGressChanged += OnHasProgress_OnProGressChanged;
        barImage.fillAmount = 0;

        Hide();
    }

    private void OnHasProgress_OnProGressChanged(object sender, IHasProgress.OnProgressChangerEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0 || e.progressNormalized == 1)
            Hide();
        else Show();
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
