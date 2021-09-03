using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200001C RID: 28
public class PokkiScript : MonoBehaviour
{
	// Token: 0x06000064 RID: 100 RVA: 0x00002C8F File Offset: 0x00000E8F
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.Wander();
		if (UnityEngine.Random.Range(0f, 10f) <= 1f)
		{
			this.AudioDevice.PlayOneShot(this.aud_pie);
		}
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00002CCC File Offset: 0x00000ECC
	private void Update()
	{
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.attackCool > 0f)
		{
			this.attackCool -= Time.deltaTime;
		}
		if (this.guilt > 0f)
		{
			this.guilt -= Time.deltaTime;
		}
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00002D3C File Offset: 0x00000F3C
	private void FixedUpdate()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player" & this.attackCool <= 0f)
		{
			this.db = true;
			this.ATTACK();
			return;
		}
		this.db = false;
		if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
		{
			this.Wander();
		}
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00002DF4 File Offset: 0x00000FF4
	private void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00002E24 File Offset: 0x00001024
	private void ATTACK()
	{
		base.transform.LookAt(new Vector3(this.player.position.x, base.transform.position.y, this.player.position.z));
		UnityEngine.Object.Instantiate<GameObject>(this.blindingObject, base.transform.position, base.transform.rotation);
		this.attackCool = 15f;
		this.db = false;
		this.TargetPlayer();
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00002EAB File Offset: 0x000010AB
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Player")
		{
			this.gc.CollectItem(16);
		}
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00002ED1 File Offset: 0x000010D1
	public void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 1f;
	}

	// Token: 0x0400004F RID: 79
	public bool db;

	// Token: 0x04000050 RID: 80
	public Transform player;

	// Token: 0x04000051 RID: 81
	public float guilt;

	// Token: 0x04000052 RID: 82
	public Transform wanderTarget;

	// Token: 0x04000053 RID: 83
	public AILocationSelectorScript wanderer;

	// Token: 0x04000054 RID: 84
	public float coolDown;

	// Token: 0x04000055 RID: 85
	private NavMeshAgent agent;

	// Token: 0x04000056 RID: 86
	public GameControllerScript gc;

	// Token: 0x04000057 RID: 87
	private float attackCool;

	// Token: 0x04000058 RID: 88
	public GameObject blindingObject;

	// Token: 0x04000059 RID: 89
	public SpriteRenderer sprite;

	// Token: 0x0400005A RID: 90
	public Sprite attack;

	// Token: 0x0400005B RID: 91
	public Sprite idle;

	// Token: 0x0400005C RID: 92
	public PlayerScript playerscript;

	// Token: 0x0400005D RID: 93
	public AudioSource AudioDevice;

	// Token: 0x0400005E RID: 94
	public AudioClip aud_pie;

	// Token: 0x0400005F RID: 95
	public int itemchance;
}
