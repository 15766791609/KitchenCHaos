using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private StoveConter stoveConter;
    [SerializeField] private GameObject stoveOnGamenObject;
    [SerializeField] private GameObject particlesGamenObject;

    private void Start()
    {
        stoveConter.OnStateChanged += OnStoveConter_OnStateChanged;
    }

    private void OnStoveConter_OnStateChanged(object sender, StoveConter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == StoveConter.State.Frying || e.state == StoveConter.State.Fried;
        stoveOnGamenObject.SetActive(showVisual);
        particlesGamenObject.SetActive(showVisual);
    }
}
