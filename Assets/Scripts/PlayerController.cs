using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movementInput;
    private Vector2 _targetVelocity;
    private Animator anim;
    private float _attackTime = 0.25f;
    private float _attackCounter = 0.25f;
    private bool _isAttacking;
    private bool isDash;
    private bool canDash = true;
    private Vector3 MoveDir;
    private GhostEffect _ghostEffect;
    private float rollTime;
    bool rollOnce = false;

    public float speed = 1.5f;
    [SerializeField]
    private float _smoothTime = 0.3f;
    [SerializeField]
    private float dashSpeed = 10f;
    [SerializeField]
    private float dashDuration = 0.3f;
    [SerializeField]
    private float dashCoolDown = 0.3f;
    [SerializeField]
    private float rollBoost = 2f;
    [SerializeField]
    private float RollTime = 2f;
    void Start()
    {
        _ghostEffect = GetComponent<GhostEffect>(); 
        _rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canDash = true;
        _ghostEffect.enabled = false;
    }
    private void FixedUpdate()
    {
        if (isDash)
        {
            return;
        }
    }
    void Update()
    {
        if (isDash)
        {
            return;
        }
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _targetVelocity = _movementInput.normalized * speed;
        _rb.velocity = Vector2.Lerp(_rb.velocity, _targetVelocity, _smoothTime);

        MoveDir = new Vector3(_movementInput.x, _movementInput.y, 0);

        anim.SetFloat("moveX", _rb.velocity.x);
        anim.SetFloat("moveY", _rb.velocity.y);

        if (_movementInput != Vector2.zero)
        {
            anim.SetFloat("lastMoveX", _movementInput.x);
            anim.SetFloat("lastMoveY", _movementInput.y);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            _attackCounter = _attackTime;
            anim.SetBool("isAttacking", true);
            _isAttacking = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            anim.SetBool("Roll", true);
            speed += rollBoost;
            rollTime = RollTime;
            rollOnce = true;
        }
        if (rollTime <= 0 && rollOnce == true)
        {
            anim.SetBool("Roll", false);
            speed -= rollBoost;
            rollOnce = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }
        if (_isAttacking)
        {
            _rb.velocity = Vector2.zero;
            _attackCounter -= Time.deltaTime;
            if (_attackCounter <= 0)
            {
                anim.SetBool("isAttacking", false);
                _isAttacking = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        _ghostEffect.enabled = true;
        canDash = false;
        isDash = true;
        _rb.velocity = new Vector2(MoveDir.x, MoveDir.y).normalized * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        _ghostEffect.enabled = false;
        isDash = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;

    }
}
