using System;
using UnityEngine;



public class Projectile : MonoBehaviour
{

	public LayerMask enemyMask;

	float speed = 10f;
	float lifeTime = 3f;
	public float damage = 1;
    readonly float skinWidth = .1f;

	void Start()
	{
		try
		{
			Destroy(gameObject, lifeTime);
			Collider[] colliders = Physics.OverlapSphere(transform.position, .1f, enemyMask);
			if (colliders.Length > 0)
			{
				OnHitObject(colliders[0], transform.position);
			}
		}
		catch (Exception)
		{
			// Debug.LogError($"Error in Start method: {ex.Message}");
		}
	}

	void Update()
	{
		float moveDistance = speed * Time.deltaTime;
		CheckCollisions(moveDistance);
		transform.Translate(Vector3.forward * moveDistance);
	}

	public void CheckCollisions(float moveDistance)
	{
        try
        {
			Ray ray = new(transform.position, transform.forward);

			if (Physics.Raycast(ray, out RaycastHit hit, moveDistance + skinWidth, enemyMask, QueryTriggerInteraction.Collide))
			{
				OnHitObject(hit.collider, hit.point);
			}
		}
		catch (Exception)
        {
			// Debug.LogError($"Error checking collisions: {ex.Message}");
		}
	}

	public void OnHitObject(Collider collider, Vector3 hitPoint)
	{
		IDamageable damageableObject = collider.GetComponent<IDamageable>();
		damageableObject?.TakeHit(damage, hitPoint, transform.forward);
		Destroy(gameObject);
	}

	public void SetSpeed(float newSpeed)
	{
		this.speed = newSpeed;
	}
}
