using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

// Token: 0x02000049 RID: 73
public class PlayerScript : MonoBehaviour
{
	// Token: 0x06000144 RID: 324 RVA: 0x00008156 File Offset: 0x00006356
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
		this.stamina = this.maxStamina;
		this.playerRotation = base.transform.rotation;
		this.mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
	}

	// Token: 0x06000145 RID: 325 RVA: 0x00008194 File Offset: 0x00006394
	private void Update()
	{
		this.MouseMove();
		this.StaminaCheck();
		this.GuiltCheck();
		if (this.blindnessMoment & this.blindTime > 0f)
		{
			this.blindTime -= Time.deltaTime;
		}
		if (this.blindTime <= 0f & this.blindnessMoment)
		{
			this.blindScreen.SetActive(false);
			this.blindnessMoment = false;
		}
		if (this.rb.velocity.magnitude > 0f)
		{
			this.gc.LockMouse();
		}
		if (this.jumpRope & (base.transform.position - this.frozenPosition).magnitude >= 1f)
		{
			this.DeactivateJumpRope();
		}
		if (this.sweepingFailsave > 0f)
		{
			this.sweepingFailsave -= Time.deltaTime;
		}
		else
		{
			this.sweeping = false;
			this.hugging = false;
		}
		if (this.stunTime > 0f)
		{
			this.stunTime -= Time.deltaTime;
		}
	}

	// Token: 0x06000146 RID: 326 RVA: 0x000082B1 File Offset: 0x000064B1
	private void FixedUpdate()
	{
		this.PlayerMove();
	}

	// Token: 0x06000147 RID: 327 RVA: 0x000082B9 File Offset: 0x000064B9
	private void MouseMove()
	{
		this.playerRotation.eulerAngles = this.playerRotation.eulerAngles + new Vector3(0f, Input.GetAxis("Mouse X") * this.mouseSensitivity, 0f);
	}

	// Token: 0x06000148 RID: 328 RVA: 0x000082F8 File Offset: 0x000064F8
	private void PlayerMove()
	{
		if (this.stunTime <= 0f)
		{
			base.transform.rotation = this.playerRotation;
			Vector3 a = new Vector3(0f, 0f, 0f);
			Vector3 b = new Vector3(0f, 0f, 0f);
			this.db = Input.GetAxisRaw("Forward");
			if (this.stamina > 0f)
			{
				if (Input.GetAxisRaw("Run") > 0f)
				{
					this.playerSpeed = this.runSpeed;
					if (this.rb.velocity.magnitude > 0.1f & !this.hugging & !this.sweeping)
					{
						this.ResetGuilt("running", 0.1f);
					}
				}
				else
				{
					this.playerSpeed = this.walkSpeed;
				}
			}
			else
			{
				this.playerSpeed = this.walkSpeed;
			}
			if (Input.GetAxis("Forward") > 0f)
			{
				a = base.transform.forward;
			}
			else if (Input.GetAxis("Forward") < 0f)
			{
				a = base.transform.forward * -1f;
			}
			if (Input.GetAxis("Strafe") > 0f)
			{
				b = base.transform.right;
			}
			else if (Input.GetAxis("Strafe") < 0f)
			{
				b = base.transform.right * -1f;
			}
			if (!this.jumpRope & !this.sweeping & !this.hugging)
			{
				this.rb.velocity = (a + b).normalized * this.playerSpeed;
				return;
			}
			if (this.sweeping)
			{
				this.rb.velocity = this.gottaSweep.velocity + (a + b).normalized * this.playerSpeed * 0.3f;
				return;
			}
			if (this.hugging)
			{
				this.rb.velocity = this.firstPrize.velocity * 1.2f + (this.firstPrizeTransform.position + new Vector3((float)Mathf.RoundToInt(this.firstPrizeTransform.forward.x), 0f, (float)Mathf.RoundToInt(this.firstPrizeTransform.forward.z)) * 3f - base.transform.position);
				return;
			}
			this.rb.velocity = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x06000149 RID: 329 RVA: 0x000085B4 File Offset: 0x000067B4
	private void StaminaCheck()
	{
		if (this.rb.velocity.magnitude > 0.1f)
		{
			if (Input.GetAxisRaw("Run") > 0f & this.stamina > 0f)
			{
				this.stamina -= this.staminaRate * Time.deltaTime;
			}
			if (this.stamina < 0f & this.stamina > -5f)
			{
				this.stamina = -5f;
			}
		}
		else if (this.stamina < this.maxStamina)
		{
			this.stamina += this.staminaRate * Time.deltaTime;
		}
		this.staminaBar.value = this.stamina / this.maxStamina * 100f;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00008684 File Offset: 0x00006884
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "blindingObject(Clone)")
		{
			this.blindTime = 15f;
			this.blindnessMoment = true;
			this.blindScreen.SetActive(true);
		}
		if (other.transform.name == "Stunningobject(Clone)")
		{
			this.StunPlayer(3f);
			return;
		}
		if (other.transform.name == "Baldi" & !this.gc.debugMode)
		{
			this.gameOver = true;
			this.gc.DeactivateLearningGame(base.gameObject);
			this.jumpscare.SetActive(true);
			return;
		}
		if (other.transform.name == "Playtime" & !this.jumpRope & this.playtime.playCool <= 0f)
		{
			this.ActivateJumpRope();
			return;
		}
		if (other.transform.name == "DeathPie(Clone)")
		{
			this.gameOver = true;
		}
	}

	// Token: 0x0600014B RID: 331 RVA: 0x00008790 File Offset: 0x00006990
	private void OnTriggerStay(Collider other)
	{
		if (other.transform.name == "Gotta Sweep")
		{
			this.sweeping = true;
			this.sweepingFailsave = 1f;
			return;
		}
		if (other.transform.name == "1st Prize" & this.firstPrize.velocity.magnitude > 5f)
		{
			this.hugging = true;
			this.sweepingFailsave = 1f;
		}
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0000880C File Offset: 0x00006A0C
	private void OnTriggerExit(Collider other)
	{
		if (other.transform.name == "Office Trigger")
		{
			this.ResetGuilt("escape", this.door.lockTime);
			return;
		}
		if (other.transform.name == "Gotta Sweep")
		{
			this.sweeping = false;
			return;
		}
		if (other.transform.name == "1st Prize")
		{
			this.hugging = false;
		}
	}

	// Token: 0x0600014D RID: 333 RVA: 0x00008884 File Offset: 0x00006A84
	public void ResetGuilt(string type, float amount)
	{
		if (amount >= this.guilt)
		{
			this.guilt = amount;
			this.guiltType = type;
		}
	}

	// Token: 0x0600014E RID: 334 RVA: 0x0000889D File Offset: 0x00006A9D
	private void GuiltCheck()
	{
		if (this.guilt > 0f)
		{
			this.guilt -= Time.deltaTime;
		}
	}

	// Token: 0x0600014F RID: 335 RVA: 0x000088BE File Offset: 0x00006ABE
	public void StunPlayer(float stunTime)
	{
		this.stunTime = stunTime;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x000088C7 File Offset: 0x00006AC7
	public void ActivateJumpRope()
	{
		this.jumpRopeScreen.SetActive(true);
		this.jumpRope = true;
		this.frozenPosition = base.transform.position;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x000088ED File Offset: 0x00006AED
	public void DeactivateJumpRope()
	{
		this.jumpRopeScreen.SetActive(false);
		this.jumpRope = false;
	}

	// Token: 0x040001F5 RID: 501
	public GameControllerScript gc;

	// Token: 0x040001F6 RID: 502
	public BaldiScript baldi;

	// Token: 0x040001F7 RID: 503
	public DoorScript door;

	// Token: 0x040001F8 RID: 504
	public PlaytimeScript playtime;

	// Token: 0x040001F9 RID: 505
	public bool gameOver;

	// Token: 0x040001FA RID: 506
	public bool jumpRope;

	// Token: 0x040001FB RID: 507
	public bool sweeping;

	// Token: 0x040001FC RID: 508
	public bool hugging;

	// Token: 0x040001FD RID: 509
	public float sweepingFailsave;

	// Token: 0x040001FE RID: 510
	private Quaternion playerRotation;

	// Token: 0x040001FF RID: 511
	public Vector3 frozenPosition;

	// Token: 0x04000200 RID: 512
	public float mouseSensitivity;

	// Token: 0x04000201 RID: 513
	public float walkSpeed;

	// Token: 0x04000202 RID: 514
	public float runSpeed;

	// Token: 0x04000203 RID: 515
	public float slowSpeed;

	// Token: 0x04000204 RID: 516
	public float maxStamina;

	// Token: 0x04000205 RID: 517
	public float staminaRate;

	// Token: 0x04000206 RID: 518
	public float guilt;

	// Token: 0x04000207 RID: 519
	public float initGuilt;

	// Token: 0x04000208 RID: 520
	private float moveX;

	// Token: 0x04000209 RID: 521
	private float moveZ;

	// Token: 0x0400020A RID: 522
	public GameObject jumpscare;

	// Token: 0x0400020B RID: 523
	private float playerSpeed;

	// Token: 0x0400020C RID: 524
	public float stamina;

	// Token: 0x0400020D RID: 525
	public Rigidbody rb;

	// Token: 0x0400020E RID: 526
	public NavMeshAgent gottaSweep;

	// Token: 0x0400020F RID: 527
	public NavMeshAgent firstPrize;

	// Token: 0x04000210 RID: 528
	public Transform firstPrizeTransform;

	// Token: 0x04000211 RID: 529
	public Slider staminaBar;

	// Token: 0x04000212 RID: 530
	public float db;

	// Token: 0x04000213 RID: 531
	public string guiltType;

	// Token: 0x04000214 RID: 532
	public GameObject jumpRopeScreen;

	// Token: 0x04000215 RID: 533
	public float stunTime;

	// Token: 0x04000216 RID: 534
	public SpriteRenderer sprite;

	// Token: 0x04000217 RID: 535
	public bool ispush;

	// Token: 0x04000218 RID: 536
	public float blindTime;

	// Token: 0x04000219 RID: 537
	public GameObject blindScreen;

	// Token: 0x0400021A RID: 538
	public bool blindnessMoment;
}
