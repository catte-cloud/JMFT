using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000042 RID: 66
public class JumpRopeScript : MonoBehaviour
{
    // Token: 0x06000126 RID: 294 RVA: 0x000070F8 File Offset: 0x000052F8
    private void OnEnable()
    {
        this.jumpDelay = 1f;
        this.ropeHit = true;
        this.jumpStarted = false;
        this.jumps = 0;
        this.jumpCount.text = 0 + "/3";
        this.playtime.audioDevice.PlayOneShot(this.playtime.aud_ReadyGo);
    }

    // Token: 0x06000127 RID: 295 RVA: 0x0000715C File Offset: 0x0000535C
    private void Update()
    {
        if (this.jumpDelay > 0f)
        {
            this.jumpDelay -= Time.deltaTime;
        }
        else if (!this.jumpStarted)
        {
            this.jumpStarted = true;
            this.ropePosition = 1f;
            this.rope.SetTrigger("ActivateJumpRope");
            this.ropeHit = false;
        }
        if (this.ropePosition > 0f)
        {
            this.ropePosition -= Time.deltaTime;
            return;
        }
        if (!this.ropeHit)
        {
            this.RopeHit();
        }
    }

    // Token: 0x06000128 RID: 296 RVA: 0x000071E9 File Offset: 0x000053E9
    private void RopeHit()
    {
        this.ropeHit = true;
        if (this.cs.jumpHeight <= 0.2f)
        {
            this.Fail();
            ticketsScript.RemoveTickets(10);
        }
        else
        {
            this.Success();
        }
        this.jumpStarted = false;
    }

    // Token: 0x06000129 RID: 297 RVA: 0x0000721C File Offset: 0x0000541C
    private void Success()
    {
        ticketsScript.AddTickets(5);
        this.playtime.audioDevice.Stop();
        this.playtime.audioDevice.PlayOneShot(this.playtime.aud_Numbers[this.jumps]);

        this.jumps++;
        this.jumpCount.text = this.jumps + "/3";
        this.jumpDelay = 0.5f;
        if (this.jumps >= 3)
        {
            this.playtime.audioDevice.Stop();
            this.playtime.audioDevice.PlayOneShot(this.playtime.aud_Congrats);
            this.ps.DeactivateJumpRope();
        }
    }

    // Token: 0x0600012A RID: 298 RVA: 0x000072D4 File Offset: 0x000054D4
    private void Fail()
    {
        ticketsScript.AddTickets(1);
        this.jumps = 0;
        this.jumpCount.text = this.jumps + "/3";
        this.jumpDelay = 2f;
        this.playtime.audioDevice.PlayOneShot(this.playtime.aud_Oops);
    }

    // Token: 0x040001B4 RID: 436
    public Text jumpCount;

    // Token: 0x040001B5 RID: 437
    public Animator rope;

    public TicketsScript ticketsScript;

    // Token: 0x040001B6 RID: 438
    public CameraScript cs;

    // Token: 0x040001B7 RID: 439
    public PlayerScript ps;

    // Token: 0x040001B8 RID: 440
    public PlaytimeScript playtime;

    // Token: 0x040001B9 RID: 441
    public int jumps;

    // Token: 0x040001BA RID: 442
    public float jumpDelay;

    // Token: 0x040001BB RID: 443
    public float ropePosition;

    // Token: 0x040001BC RID: 444
    public bool ropeHit;

    // Token: 0x040001BD RID: 445
    public bool jumpStarted;
}
