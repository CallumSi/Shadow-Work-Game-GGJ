using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [Tooltip("Animator for the Jenny Character")]
    [SerializeField]
    private Animator jennyCharacterAnimator;

    public void ChangeAnimation(int animation)
    {
        var animationType = (Animation)animation;
        jennyCharacterAnimator.SetTrigger(animationType.ToString());
    }

    public enum Animation
    {
        idle,
        pushing_left,
        pushing_right,
        pickup_left,
        pickup_right,
        jump,
        walking_left,
        walking_right,
    }
}
