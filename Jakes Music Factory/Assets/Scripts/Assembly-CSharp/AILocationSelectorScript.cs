using System;
using UnityEngine;

// Token: 0x02000022 RID: 34
public class AILocationSelectorScript : MonoBehaviour
{
	// Token: 0x06000084 RID: 132 RVA: 0x000035B8 File Offset: 0x000017B8
	public void GetNewTarget()
	{
		this.id = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 28f));
		base.transform.position = this.newLocation[this.id].position;
		this.ambience.PlayAudio();
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00003608 File Offset: 0x00001808
	public void GetNewTargetHallway()
	{
		this.id = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 15f));
		base.transform.position = this.newLocation[this.id].position;
		this.ambience.PlayAudio();
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00003657 File Offset: 0x00001857
	public void QuarterExclusive()
	{
		this.id = Mathf.RoundToInt(UnityEngine.Random.Range(1f, 15f));
		base.transform.position = this.newLocation[this.id].position;
	}

	// Token: 0x04000097 RID: 151
	public Transform[] newLocation = new Transform[29];

	// Token: 0x04000098 RID: 152
	public AmbienceScript ambience;

	// Token: 0x04000099 RID: 153
	private int id;
}
