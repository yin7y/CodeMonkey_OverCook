using NUnit.Framework.Internal.Commands;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    const string IS_WALKING = "IsWalking";
    [SerializeField] Player player;
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
