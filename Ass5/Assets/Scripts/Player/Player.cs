using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] Healthbar healthbar;
    public float health, maxHealth = 1.0f;
    public UnityEvent OnDeath;

    public InputAction movementInput;
    public InputAction attackInput;

    private Vector2 moveVector;
    private Rigidbody rb;

    public float movementSpeed;
    public float attackTime;

    private float timestamp;
    PlayerWeapon playerWeapon;

    public UnityEvent OnAttack;

    private void Awake()
    {
        playerWeapon = GetComponent<PlayerWeapon>();
        healthbar = GetComponentInChildren<Healthbar>();

        movementInput.Enable();
        movementInput.performed += ReadMoveInput;
        movementInput.canceled += ReadMoveInput;

        attackInput.Enable();
        attackInput.performed += Attack;

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = (transform.forward * moveVector.y) + (transform.right * moveVector.x);

        rb.linearVelocity = new Vector3(moveDirection.x * movementSpeed, rb.linearVelocity.y, moveDirection.z * movementSpeed);
    }

    private void ReadMoveInput(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack here");
        OnAttack?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            timestamp = Time.time;
            OnDeath?.Invoke();
        }
    }

    public void Die()
    {
        StartCoroutine(DieWait());
    }

    IEnumerator DieWait()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(0);
    }
}

