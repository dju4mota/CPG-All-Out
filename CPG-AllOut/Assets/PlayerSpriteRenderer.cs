using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private AnimationController anim;
    private Player player;
    public Sprite[] idleSprites;
    //private Anim run;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        anim = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void LateUpdate()
    {
        if (player.moveDirection == Vector2.zero)
        {
            spriteRenderer.sprite = anim.Animator.GetCurrentAnimatorStateInfo(0).IsName("Up") ? idleSprites[0] :
                              anim.Animator.GetCurrentAnimatorStateInfo(0).IsName("Down") ? idleSprites[1] :
                              anim.Animator.GetCurrentAnimatorStateInfo(0).IsName("L") ? idleSprites[2] :
                              anim.Animator.GetCurrentAnimatorStateInfo(0).IsName("R") ? idleSprites[3] :
                              anim.Animator.GetCurrentAnimatorStateInfo(0).IsName("UL") ? idleSprites[4] :
                              anim.Animator.GetCurrentAnimatorStateInfo(0).IsName("UR") ? idleSprites[5] :
                              anim.Animator.GetCurrentAnimatorStateInfo(0).IsName("DL") ? idleSprites[6] :
                              anim.Animator.GetCurrentAnimatorStateInfo(0).IsName("DR") ? idleSprites[7] :
                              idleSprites[0]; // fallback
            anim.Animator.enabled = false;
        }
        else
        {
            anim.Animator.enabled = true; // reativa animação caso tenha sido desativada
            {
                if (player.moveDirection.x > 0.15f)
                {
                    if (player.moveDirection.y > 0.15f)
                        anim.ChangeAnimationState("UR");
                    else if (player.moveDirection.y < -0.15f)
                        anim.ChangeAnimationState("DR");
                    else
                    {
                        anim.ChangeAnimationState("R");
                    }
                }

                else if (player.moveDirection.x < -0.15f)
                {
                    if (player.moveDirection.y > 0.15f)
                        anim.ChangeAnimationState("UL");
                    else if (player.moveDirection.y < -0.15f)
                        anim.ChangeAnimationState("DL");
                    else
                    {
                        anim.ChangeAnimationState("L");
                    }
                }

                else
                {
                    if (player.moveDirection.y > 0f)
                        anim.ChangeAnimationState("Up");
                    else
                        anim.ChangeAnimationState("Down");
                }
            }
        }
}}