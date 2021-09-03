using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000066 RID: 102
public class VJDNscript : MonoBehaviour
{
	// Token: 0x060001D4 RID: 468 RVA: 0x0000AA89 File Offset: 0x00008C89
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.Wander();
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x0000AAA0 File Offset: 0x00008CA0
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

	// Token: 0x060001D6 RID: 470 RVA: 0x0000AB10 File Offset: 0x00008D10
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

	// Token: 0x060001D7 RID: 471 RVA: 0x0000ABC8 File Offset: 0x00008DC8
	private void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 10f;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x0000ABF7 File Offset: 0x00008DF7
	private void ATTACK()
	{
		this.attackCool = 15f;
		this.db = false;
		this.TargetPlayer();
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x0000AC11 File Offset: 0x00008E11
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Player")
		{
			this.gc.ResetItem();
		}
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0000AC35 File Offset: 0x00008E35
	public void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 1f;
	}

	// Token: 0x040002E2 RID: 738
	public bool db;

	// Token: 0x040002E3 RID: 739
	public Transform player;

	// Token: 0x040002E4 RID: 740
	public float guilt;

	// Token: 0x040002E5 RID: 741
	public Transform wanderTarget;

	// Token: 0x040002E6 RID: 742
	public AILocationSelectorScript wanderer;

	// Token: 0x040002E7 RID: 743
	public float coolDown;

	// Token: 0x040002E8 RID: 744
	private NavMeshAgent agent;

	// Token: 0x040002E9 RID: 745
	public GameControllerScript gc;

	// Token: 0x040002EA RID: 746
	private float attackCool;

	// Token: 0x040002EB RID: 747
	public PlayerScript playerscript;
}
