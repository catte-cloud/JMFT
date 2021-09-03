using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class WaterFountainScript : MonoBehaviour
{
	// Token: 0x0600000A RID: 10 RVA: 0x0000205E File Offset: 0x0000025E
	private void Start()
	{
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000020CC File Offset: 0x000002CC
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f && Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f)), out raycastHit) && (raycastHit.transform == base.transform & Vector3.Distance(this.playerposition.position, base.transform.position) < 15f))
		{
			this.player.stamina = 100f;
		}
	}

	// Token: 0x04000006 RID: 6
	public PlayerScript player;

	// Token: 0x04000007 RID: 7
	public Transform playerposition;
}
