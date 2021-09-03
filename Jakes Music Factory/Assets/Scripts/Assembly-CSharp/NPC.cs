using System;
using UnityEngine;

// Token: 0x0200005F RID: 95
[Serializable]
public class NPC : MonoBehaviour
{
	// Token: 0x060001B9 RID: 441 RVA: 0x0000A36D File Offset: 0x0000856D
	private void Start()
	{
		this.dialogueSystem = UnityEngine.Object.FindObjectOfType<DialogueSystem>();
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0000A37C File Offset: 0x0000857C
	private void Update()
	{
		Vector3 position = Camera.main.WorldToScreenPoint(this.NPCCharacter.position);
		position.y += 175f;
		this.ChatBackGround.position = position;
	}

	// Token: 0x060001BB RID: 443 RVA: 0x0000A3BC File Offset: 0x000085BC
	public void OnTriggerStay(Collider other)
	{
		base.gameObject.GetComponent<NPC>().enabled = true;
		UnityEngine.Object.FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
		if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
		{
			base.gameObject.GetComponent<NPC>().enabled = true;
			this.dialogueSystem.Names = this.Name;
			this.dialogueSystem.dialogueLines = this.sentences;
			UnityEngine.Object.FindObjectOfType<DialogueSystem>().NPCName();
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x0000A441 File Offset: 0x00008641
	public void OnTriggerExit()
	{
		UnityEngine.Object.FindObjectOfType<DialogueSystem>().OutOfRange();
		base.gameObject.GetComponent<NPC>().enabled = false;
	}

	// Token: 0x040002C9 RID: 713
	public Transform ChatBackGround;

	// Token: 0x040002CA RID: 714
	public Transform NPCCharacter;

	// Token: 0x040002CB RID: 715
	private DialogueSystem dialogueSystem;

	// Token: 0x040002CC RID: 716
	public string Name;

	// Token: 0x040002CD RID: 717
	[TextArea(5, 10)]
	public string[] sentences;
}
