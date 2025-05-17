using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private AnimationController anim;
    private Player player;
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