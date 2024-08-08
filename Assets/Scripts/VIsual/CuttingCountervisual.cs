using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCountervisual : MonoBehaviour
{
    private const string CUT = "Cut";  

    [SerializeField] private CuttingCounter cuttingCounter;
    private Animator counterAnimator;

    private void Awake()
    {
        counterAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        cuttingCounter.OnCut += OnCut;
    }

    private void OnCut(object sender, EventArgs e)
    {
        counterAnimator.SetTrigger(CUT);
    }
}
