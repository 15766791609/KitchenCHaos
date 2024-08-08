using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCountervisual : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";  

    [SerializeField] private ContainerCounter containerCounter;
    private Animator counterAnimator;

    private void Awake()
    {
        counterAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        containerCounter.OnPlayerGrabbedObject += OnPlayerGrabbedObject;
    }

    private void OnPlayerGrabbedObject(object sender, System.EventArgs e)
    {
        counterAnimator.SetTrigger(OPEN_CLOSE);
    }
}
