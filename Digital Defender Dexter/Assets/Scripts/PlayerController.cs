using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    public Vector3 playerMoveDirection;
    public float playerMaxHealth;
    public float playerHealth;
    private Animator animator;

    public int experience;
    public int currentLevel;
    public int maxLevel;
    public List<int> playerLevels;

    public Weapon activeWeapon;

    private bool isImmune;
    [SerializeField] private float immueDuration;
    [SerializeField] private float immunityTimer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    
    }

    private void Start()
    {
        for (int i = playerLevels.Count; i < maxLevel; i++)
        {
            playerLevels.Add(Mathf.CeilToInt(playerLevels[playerLevels.Count - 1] * 1.1f + 15));
        }
        playerHealth = playerMaxHealth;
        UIController.Instance.UpdateHealthSlider();
        UIController.Instance.UpdateExperienceSlider();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        playerMoveDirection = new Vector2(inputX, inputY).normalized;

        if (immunityTimer > 0)
        {
            immunityTimer -= Time.deltaTime;
        } else
        {
            isImmune = false;
        }

        bool isMoving = playerMoveDirection.sqrMagnitude > 0.1f;
        animator.SetBool("isMoving", isMoving);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3 (playerMoveDirection.x * moveSpeed * Time.deltaTime, playerMoveDirection.y * moveSpeed * Time.deltaTime);

    }

    public void TakeDamage(float damage)
    {
        if (!isImmune)
        {
            isImmune = true;
            immunityTimer = immueDuration;
            playerHealth -= damage;
            UIController.Instance.UpdateHealthSlider();
            if (playerHealth <= 0)
            {
                gameObject.SetActive(false);
                GameManager.Instance.GameOver();
            }
        }
    }


    public void GetExperience(int experienceToGet)
    {
        experience += experienceToGet;
        UIController.Instance.UpdateExperienceSlider();
        if (experience >= playerLevels[currentLevel - 1])
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        experience -= playerLevels[currentLevel - 1];
        currentLevel++;
        UIController.Instance.UpdateExperienceSlider();
        UIController.Instance.levelUpScreenOpen();
        UIController.Instance.levelUpButtons[0].ActivateButton(activeWeapon);
    }
}
