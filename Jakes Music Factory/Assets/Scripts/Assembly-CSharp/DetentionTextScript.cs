using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000034 RID: 52
public class DetentionTextScript : MonoBehaviour
{
	// Token: 0x060000D8 RID: 216 RVA: 0x00004A64 File Offset: 0x00002C64
	private void Start()
	{
		this.text = base.GetComponent<Text>();
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00004A74 File Offset: 0x00002C74
	private void Update()
	{
		if (this.door.lockTime > 0f)
		{
			this.text.text = "Calm Down Time! \n" + Mathf.CeilToInt(this.door.lockTime) + " Till you're free.";
			return;
		}
		this.text.text = string.Empty;
	}

	// Token: 0x040000FD RID: 253
	public DoorScript door;

	// Token: 0x040000FE RID: 254
	private Text text;
}
