using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatior : MonoBehaviour
{
    private const string ISWALKING = "IsWalking";
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimatiorState();
    }
    private void ChangeAnimatiorState()
    {
        animator.SetBool(ISWALKING, Player.Instance.IsWarking());
    }
}
