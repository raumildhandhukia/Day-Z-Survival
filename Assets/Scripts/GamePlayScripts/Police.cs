using UnityEngine;

public class Police : Enemy
{

	public Transform zombieModel;
	public GameObject dialogueUI;
	public GameObject player;

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void Start()
	{
		base.Start();
	}

	protected override void Update()
	{
		base.Update();
	}

	public override void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection)
	{
		if (Vector3.Distance(player.transform.position, this.transform.position) >= 40f)
		{
			return;
		}
		if (health - damage <= 0)
		{
			Destroy(Instantiate(deathEffect, hitPoint, Quaternion.FromToRotation(Vector3.forward, hitDirection)).gameObject, deathEffect.main.startLifetimeMultiplier);
			Destroy(this);
			if (agent != null)
			{
				Destroy(agent);
			}
			if (myBoxCollider != null)
			{
				Destroy(myBoxCollider);
			}
			AudioManager.instance.PlaySound("ZombieDie", transform.position);
		}
		else
		{
			AudioManager.instance.PlaySound("ZombieTakeHit", transform.position);
		}
		base.TakeHit(damage);
	}

	protected override void Die()
	{
		isDead = true;
		OnDeath?.Invoke();
		dialogueUI.SetActive(true);
		Destroy(dialogueUI, 2f);
		Destroy(gameObject);
	}

}