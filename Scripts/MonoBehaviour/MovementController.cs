using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float fMovementSpeed = 3.0f;
    Vector2 v2Movement = new Vector2();
    
    Animator animator;
    
    string strAnimationState = "AnimationState";
    Rigidbody2D rb2d;

    enum CHAR_STATES
    {
        NONE,
        WALK_EAST,
        WALK_NORTH,
        WALK_SOUTH,
        WALK_WEST,        
        IDLE,
        _MAX_
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();        
    }
        
    private void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCharacter();        
    }

    private void MoveCharacter()
    {
        v2Movement.x = Input.GetAxisRaw("Horizontal");
        v2Movement.y = Input.GetAxisRaw("Vertical");

        //벡터를 정규화하여 플레이어가 대각선, 수직, 수평 어느 방향으로 움직이든 일정한 속력 유지
        v2Movement.Normalize();

        rb2d.velocity = v2Movement * fMovementSpeed;
    }

    private void UpdateState()
    {
        if (v2Movement.x > 0)
        {
            animator.SetInteger(strAnimationState, (int)CHAR_STATES.WALK_EAST);
        }
        else if (v2Movement.x < 0)
        {
            animator.SetInteger(strAnimationState, (int)CHAR_STATES.WALK_WEST);
        }
        else if (v2Movement.y > 0)
        {
            animator.SetInteger(strAnimationState, (int)CHAR_STATES.WALK_NORTH);
        }
        else if (v2Movement.y < 0)
        {
            animator.SetInteger(strAnimationState, (int)CHAR_STATES.WALK_SOUTH);
        }
        else
        {
            animator.SetInteger(strAnimationState, (int)CHAR_STATES.IDLE);
        }
    }
}
