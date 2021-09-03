using System;
using UnityEngine;

// Token: 0x02000046 RID: 70
public class NotebookScript : MonoBehaviour
{
	// Token: 0x0600013B RID: 315 RVA: 0x0000796C File Offset: 0x00005B6C
	private void Start()
	{
		this.up = true;
	}

	// Token: 0x0600013C RID: 316 RVA: 0x00007978 File Offset: 0x00005B78
	private void Update()
	{
		if (this.gc.mode == "endless")
		{
			if (this.respawnTime > 0f)
			{
				if ((base.transform.position - this.player.position).magnitude > 60f)
				{
					this.respawnTime -= Time.deltaTime;
				}
			}
			else if (!this.up)
			{
				base.transform.position = new Vector3(base.transform.position.x, 4f, base.transform.position.z);
				this.up = true;
				this.audioDevice.Play();
			}
		}
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && (raycastHit.transform.tag == "Notebook" & Vector3.Distance(this.player.position, base.transform.position) < this.openingDistance))
		{
			base.transform.position = new Vector3(base.transform.position.x, -20f, base.transform.position.z);
			this.up = false;
			this.respawnTime = 120f;
			this.gc.CollectNotebook();
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.learningGame);
			gameObject.GetComponent<MathGameScript>().gc = this.gc;
			gameObject.GetComponent<MathGameScript>().baldiScript = this.bsc;
			gameObject.GetComponent<MathGameScript>().playerPosition = this.player.position;
		}
	}

	// Token: 0x040001EA RID: 490
	public float openingDistance;

	// Token: 0x040001EB RID: 491
	public GameControllerScript gc;

	// Token: 0x040001EC RID: 492
	public BaldiScript bsc;

	// Token: 0x040001ED RID: 493
	public float respawnTime;

	// Token: 0x040001EE RID: 494
	public bool up;

	// Token: 0x040001EF RID: 495
	public Transform player;

	// Token: 0x040001F0 RID: 496
	public GameObject learningGame;

	// Token: 0x040001F1 RID: 497
	public AudioSource audioDevice;
}
