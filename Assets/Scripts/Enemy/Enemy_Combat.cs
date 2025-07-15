using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
	private Animator enemyAnimator;
	private Transform player;
	private bool isAttacking = false;

	[Header("Attack Settings")]
	public float attackRange = 1f;
	public float attackDuration = 1f; // Duration of attack (matches animation)
	public Collider2D enemyWeaponCollider;

	void Start()
	{
		enemyAnimator = GetComponentInParent<Animator>();
		if (enemyAnimator == null)
			Debug.LogError("Enemy Animator not found!");

		player = GameObject.FindWithTag("Player")?.transform;

		if (enemyWeaponCollider != null)
			enemyWeaponCollider.enabled = false;
	}

	void Update()
	{
		if (player == null || isAttacking) return;

		if (Vector2.Distance(transform.position, player.position) <= attackRange)
		{
			StartAttack();
		}
	}

	private void StartAttack()
	{
		isAttacking = true;
		enemyAnimator?.SetTrigger("2_Attack");

		Invoke(nameof(ResetAttackState), attackDuration);
	}

	// Called by Animation Events
	public void ActivateCollider()
	{
		if (enemyWeaponCollider != null)
			enemyWeaponCollider.enabled = true;
	}

	public void DeactivateCollider()
	{
		if (enemyWeaponCollider != null)
			enemyWeaponCollider.enabled = false;
	}

	private void ResetAttackState()
	{
		isAttacking = false;
	}
}
