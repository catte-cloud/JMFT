using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x0200005A RID: 90
public class YeetScript : MonoBehaviour
{
	// Token: 0x0600019D RID: 413 RVA: 0x00009D95 File Offset: 0x00007F95
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.Wander();
		if (UnityEngine.Random.Range(0f, 10f) <= 1f)
		{
			this.AudioDevice.PlayOneShot(this.aud_pie);
		}
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00009DD0 File Offset: 0x00007FD0
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

	// Token: 0x0600019F RID: 415 RVA: 0x00009E40 File Offset: 0x00008040
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

	// Token: 0x060001A0 RID: 416 RVA: 0x00009F03 File Offset: 0x00008103
	public void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
		this.sprite.sprite = this.idle;
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x00009F44 File Offset: 0x00008144
	private void ATTACK()
	{
		base.transform.LookAt(new Vector3(this.player.position.x, base.transform.position.y, this.player.position.z));
		UnityEngine.Object.Instantiate<GameObject>(this.Stunningobject, base.transform.position, base.transform.rotation);
		this.attackCool = 15f;
		this.sprite.sprite = this.attack;
		this.db = false;
		this.Wander();
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00009FDC File Offset: 0x000081DC
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Jazzy" & this.guilt > 0f)
		{
			this.agent.Warp(new Vector3(-2763f, 4f, 113f));
		}
	}

	// Token: 0x040002A3 RID: 675
	public bool db;

	// Token: 0x040002A4 RID: 676
	public Transform player;

	// Token: 0x040002A5 RID: 677
	public float guilt;

	// Token: 0x040002A6 RID: 678
	public Transform wanderTarget;

	// Token: 0x040002A7 RID: 679
	public AILocationSelectorScript wanderer;

	// Token: 0x040002A8 RID: 680
	public float coolDown;

	// Token: 0x040002A9 RID: 681
	private NavMeshAgent agent;

	// Token: 0x040002AA RID: 682
	public GameControllerScript gc;

	// Token: 0x040002AB RID: 683
	private float attackCool;

	// Token: 0x040002AC RID: 684
	public GameObject Stunningobject;

	// Token: 0x040002AD RID: 685
	public SpriteRenderer sprite;

	// Token: 0x040002AE RID: 686
	public Sprite attack;

	// Token: 0x040002AF RID: 687
	public Sprite idle;

	// Token: 0x040002B0 RID: 688
	public PlayerScript playerscript;

	// Token: 0x040002B1 RID: 689
	public AudioSource AudioDevice;

	// Token: 0x040002B2 RID: 690
	public AudioClip aud_pie;
}
