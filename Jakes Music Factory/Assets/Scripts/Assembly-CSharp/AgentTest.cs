using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000021 RID: 33
public class AgentTest : MonoBehaviour
{
	// Token: 0x0600007E RID: 126 RVA: 0x00003491 File Offset: 0x00001691
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.Wander();
	}

	// Token: 0x0600007F RID: 127 RVA: 0x000034A5 File Offset: 0x000016A5
	private void Update()
	{
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
	}

	// Token: 0x06000080 RID: 128 RVA: 0x000034CC File Offset: 0x000016CC
	private void FixedUpdate()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player")
		{
			this.db = false;
			if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
			{
				this.Wander();
			}
		}
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00003565 File Offset: 0x00001765
	private void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
	}

	// Token: 0x06000082 RID: 130 RVA: 0x00003594 File Offset: 0x00001794
	private void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 1f;
	}

	// Token: 0x04000091 RID: 145
	public bool db;

	// Token: 0x04000092 RID: 146
	public Transform player;

	// Token: 0x04000093 RID: 147
	public Transform wanderTarget;

	// Token: 0x04000094 RID: 148
	public AILocationSelectorScript wanderer;

	// Token: 0x04000095 RID: 149
	public float coolDown;

	// Token: 0x04000096 RID: 150
	private NavMeshAgent agent;
}
