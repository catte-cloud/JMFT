using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200001E RID: 30
public class PranksterScript : MonoBehaviour
{
	// Token: 0x0600006F RID: 111 RVA: 0x00002EFE File Offset: 0x000010FE
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.Wander();
		if (UnityEngine.Random.Range(0f, 10f) <= 1f)
		{
			this.AudioDevice.PlayOneShot(this.aud_pie);
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00002F3C File Offset: 0x0000113C
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

	// Token: 0x06000071 RID: 113 RVA: 0x00002FAC File Offset: 0x000011AC
	private void FixedUpdate()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player" & this.attackCool <= 0f)
		{
			this.db = true;
			this.ATTACK();
			this.guilt = 20f;
			return;
		}
		this.db = false;
		if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
		{
			this.Wander();
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0000306F File Offset: 0x0000126F
	private void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
		this.sprite.sprite = this.idle;
	}

	// Token: 0x06000073 RID: 115 RVA: 0x000030B0 File Offset: 0x000012B0
	private void ATTACK()
	{
		base.transform.LookAt(new Vector3(this.player.position.x, base.transform.position.y, this.player.position.z));
		UnityEngine.Object.Instantiate<GameObject>(this.blindingObject, base.transform.position, base.transform.rotation);
		this.attackCool = 15f;
		this.sprite.sprite = this.attack;
		this.db = false;
		this.Wander();
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00003148 File Offset: 0x00001348
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Jazzy" & this.guilt > 0f)
		{
			this.agent.Warp(new Vector3(-2763f, 4f, 113f));
		}
	}

	// Token: 0x04000061 RID: 97
	public bool db;

	// Token: 0x04000062 RID: 98
	public Transform player;

	// Token: 0x04000063 RID: 99
	public float guilt;

	// Token: 0x04000064 RID: 100
	public Transform wanderTarget;

	// Token: 0x04000065 RID: 101
	public AILocationSelectorScript wanderer;

	// Token: 0x04000066 RID: 102
	public float coolDown;

	// Token: 0x04000067 RID: 103
	private NavMeshAgent agent;

	// Token: 0x04000068 RID: 104
	public GameControllerScript gc;

	// Token: 0x04000069 RID: 105
	private float attackCool;

	// Token: 0x0400006A RID: 106
	public GameObject blindingObject;

	// Token: 0x0400006B RID: 107
	public SpriteRenderer sprite;

	// Token: 0x0400006C RID: 108
	public Sprite attack;

	// Token: 0x0400006D RID: 109
	public Sprite idle;

	// Token: 0x0400006E RID: 110
	public PlayerScript playerscript;

	// Token: 0x0400006F RID: 111
	public AudioSource AudioDevice;

	// Token: 0x04000070 RID: 112
	public AudioClip aud_pie;
}
