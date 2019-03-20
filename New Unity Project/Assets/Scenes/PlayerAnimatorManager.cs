using Photon.Realtime;
using Photon.Pun;
using UnityEngine;
namespace Com.Dirox.MyGame
{
    public class PlayerAnimatorManager : MonoBehaviour {
        #region MonoBehaviour Callbacks

        private Animator animator;
        void Start () {
            animator = GetComponent<Animator>();
            if (!animator)
            {
                Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
            }
	    }
	
	    void Update () {
            if (!animator)
            {
                return;
            }
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0)
            {
                v = 0;
            }
            animator.SetFloat("Speed", h * h + v * v);
            animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);

            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if(stateInfo.IsName("Base Layer.Run"))
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    animator.SetTrigger("Jump");
                }
            }
        }
        #endregion

        #region Private Fields

        [SerializeField]
        private float directionDampTime = 0.25f;

        #endregion


    }
}
