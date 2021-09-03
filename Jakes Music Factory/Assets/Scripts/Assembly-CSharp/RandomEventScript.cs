using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200001F RID: 31
public class RandomEventScript : MonoBehaviour
{
	// Token: 0x06000076 RID: 118 RVA: 0x0000319C File Offset: 0x0000139C
	private void Update()
	{
		if (this.eventCooldown > 0f)
		{
			this.eventCooldown -= Time.deltaTime;
		}
		else if (this.eventStarted)
		{
			this.StopEvent();
		}
		if (this.eventTimer > 0f)
		{
			this.eventTimer -= Time.deltaTime;
			return;
		}
		if (!this.eventStarted)
		{
			base.StartCoroutine(this.StartEvent());
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x0000320D File Offset: 0x0000140D
	public IEnumerator StartEvent()
	{
		this.eventStarted = true;
		this.audioDevice.PlayOneShot(this.eventBell);
		yield return new WaitForSeconds(3f);
		this.eventChance = UnityEngine.Random.Range(0, 7);
		this.hudBackground.gameObject.SetActive(true);
		this.hudText.text = this.eventTexts[this.eventChance];
		if (this.eventChance == 0)
		{
			RenderSettings.ambientLight = Color.black;
			this.audioDevice.PlayOneShot(this.mus_Scary);
		}
		if (this.eventChance == 1)
		{
			RenderSettings.fog = true;
			RenderSettings.fogColor = Color.white;
			this.audioDevice.PlayOneShot(this.mus_Foggy);
		}
		if (this.eventChance == 2)
		{
			this.gc.principal.SetActive(false);
			this.gc.glitchy.SetActive(false);
		}
		if (this.eventChance == 3)
		{
			this.gc.madglitchy.SetActive(true);
			this.gc.glitchy.SetActive(false);
		}
		if (this.eventChance == 4)
		{
			this.gc.CollectItem(5);
			this.gc.CollectItem(5);
			this.gc.CollectItem(5);
			this.gc.CollectItem(5);
			this.gc.CollectItem(5);
			this.gc.CollectItem(5);
		}
		if (this.eventChance == 5)
		{
			this.gc.principal.SetActive(false);
			this.PartyJazzy.SetActive(true);
			this.gc.glitchy.SetActive(false);
			this.PartyGlitchy.SetActive(true);
			this.gc.playtime.SetActive(false);
			this.PartyDancey.SetActive(true);
			this.PartyPrankster.SetActive(true);
			this.gc.jake.TargetPlayer();
			this.Item1.SetActive(true);
			this.prankster.SetActive(false);
		}
		if (this.eventChance == 6)
		{
			this.EnemyRoom.SetActive(true);
			this.gc.gottaSweep.SetActive(true);
			this.DissaperanceWall.SetActive(false);
		}
		if (this.eventChance == 7)
		{
			this.secretdoor.SetActive(true);
			this.secretwall.SetActive(false);
		}
		this.eventTimer = UnityEngine.Random.Range(80f, 100f);
		yield break;
	}

	// Token: 0x06000078 RID: 120 RVA: 0x0000321C File Offset: 0x0000141C
	private void StopEvent()
	{
		if (this.eventChance == 0)
		{
			RenderSettings.ambientLight = Color.gray;
			this.audioDevice.PlayOneShot(this.mus_Empty);
		}
		if (this.eventChance == 1)
		{
			RenderSettings.fog = false;
			this.audioDevice.PlayOneShot(this.mus_Empty);
		}
		if (this.eventChance == 2)
		{
			this.gc.principal.SetActive(true);
			this.gc.glitchy.SetActive(true);
			this.audioDevice.PlayOneShot(this.mus_Empty);
		}
		if (this.eventChance == 3)
		{
			this.gc.glitchy.SetActive(true);
			this.gc.madglitchy.SetActive(false);
			this.audioDevice.PlayOneShot(this.mus_Empty);
			this.madglitchytarget.TargetPlayer();
		}
		if (this.eventChance == 4)
		{
			this.audioDevice.PlayOneShot(this.mus_Empty);
		}
		if (this.eventChance == 5)
		{
			this.gc.principal.SetActive(true);
			this.PartyJazzy.SetActive(false);
			this.gc.glitchy.SetActive(true);
			this.PartyGlitchy.SetActive(false);
			this.gc.playtime.SetActive(true);
			this.PartyDancey.SetActive(false);
			this.PartyPrankster.SetActive(false);
			this.Item1.SetActive(false);
			this.prankster.SetActive(true);
		}
		int num = this.eventChance;
		if (this.eventChance == 7)
		{
			this.secretdoor.SetActive(false);
			this.secretwall.SetActive(true);
		}
		this.eventCooldown = UnityEngine.Random.Range(50f, 75f);
		this.eventTimer = UnityEngine.Random.Range(20f, 30f);
		this.hudBackground.gameObject.SetActive(false);
		this.eventStarted = false;
	}

	// Token: 0x04000071 RID: 113
	public float eventTimer;

	// Token: 0x04000072 RID: 114
	public float eventCooldown;

	// Token: 0x04000073 RID: 115
	public int eventChance;

	// Token: 0x04000074 RID: 116
	public int ItemeventChance;

	// Token: 0x04000075 RID: 117
	private string[] eventTexts = new string[]
	{
		"The Lights Have Gone Out...? Why!?",
		"RenderSettings.fog = true;",
		"[Removed Glitchy And Jazzy Temporarily.]",
		"Glitchy is coming for you...",
		"It's Pay Day! Have some tickets!",
		"Party Time! Come To the Calm Down Corner to Recive a Prize!",
		"Brush Drum has returned!",
		"A Surpise Room has been created! find it before its gone."
	};

	// Token: 0x04000076 RID: 118
	private bool eventStarted;

	// Token: 0x04000077 RID: 119
	public Image hudBackground;

	// Token: 0x04000078 RID: 120
	public Text hudText;

	// Token: 0x04000079 RID: 121
	public AudioClip eventBell;

	// Token: 0x0400007A RID: 122
	public AudioSource audioDevice;

	// Token: 0x0400007B RID: 123
	public GameControllerScript gc;

	// Token: 0x0400007C RID: 124
	public AudioSource audioDeviceLoop;

	// Token: 0x0400007D RID: 125
	public AudioClip mus_Scary;

	// Token: 0x0400007E RID: 126
	public AudioClip mus_Empty;

	// Token: 0x0400007F RID: 127
	public AudioClip mus_Foggy;

	// Token: 0x04000080 RID: 128
	public AudioClip mus_Party2;

	// Token: 0x04000081 RID: 129
	public GameObject PartyGlitchy;

	// Token: 0x04000082 RID: 130
	public GameObject PartyPrankster;

	// Token: 0x04000083 RID: 131
	public GameObject PartyYeet;

	// Token: 0x04000084 RID: 132
	public GameObject PartyJazzy;

	// Token: 0x04000085 RID: 133
	public GameObject PartyDancey;

	// Token: 0x04000086 RID: 134
	public BaldiScript jake;

	// Token: 0x04000087 RID: 135
	public GameObject Item1;

	// Token: 0x04000088 RID: 136
	public GameObject Item2;

	// Token: 0x04000089 RID: 137
	public GameObject Item3;

	// Token: 0x0400008A RID: 138
	public GameObject EnemyRoom;

	// Token: 0x0400008B RID: 139
	public GameObject DissaperanceWall;

	// Token: 0x0400008C RID: 140
	public BaldiScript madglitchytarget;

	// Token: 0x0400008D RID: 141
	public GameObject secretwall;

	// Token: 0x0400008E RID: 142
	public GameObject secretdoor;

	// Token: 0x0400008F RID: 143
	public GameObject prankster;
}
