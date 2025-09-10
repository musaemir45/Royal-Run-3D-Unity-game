using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{   
    [Header("Referances")]
    LevelGenerator levelGenerator;
    const string hitString = "Hit";
    float cooldownTimer = 0f;

    [Header("Player Collision Settings")]
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustCahngeMoveSpeedAmount = -2f;
    [SerializeField] Animator animator;
    
    
    
    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustCahngeMoveSpeedAmount);
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
        
    }
}
