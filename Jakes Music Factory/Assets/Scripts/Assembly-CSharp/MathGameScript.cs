using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000043 RID: 67
public class MathGameScript : MonoBehaviour
{
    // Token: 0x0600012C RID: 300 RVA: 0x00007330 File Offset: 0x00005530
    private void Start()
    {
        this.gc.ActivateLearningGame();
        if (this.gc.notebooks == 1 && !this.gc.spoopMode)
        {
            this.QueueAudio(this.bal_howto);
        }
        this.NewProblem();
        if (this.gc.spoopMode)
        {
            this.baldiFeedTransform.position = new Vector3(-1000f, -1000f, 0f);
        }
    }

    // Token: 0x0600012D RID: 301 RVA: 0x000073A4 File Offset: 0x000055A4
    private void Update()
    {
        if (!this.baldiAudio.isPlaying)
        {
            if (this.audioInQueue > 0)
            {
                this.PlayQueue();
            }
            this.baldiFeed.SetBool("talking", false);
        }
        else
        {
            this.baldiFeed.SetBool("talking", true);
        }
        if (this.problem > 3)
        {
            this.endDelay -= 1f * Time.unscaledDeltaTime;
            if (this.endDelay <= 0f)
            {
                this.ExitGame();
            }
        }
    }

    // Token: 0x0600012E RID: 302 RVA: 0x00007428 File Offset: 0x00005628
    public void NewProblem()
    {
        if (this.problem != 4)
        {
            this.problem++;
            if (this.problem != 3 || this.gc.notebooks <= 1)
            {
                this.currans = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 2f));
                this.QueueAudio(this.notes[this.currans]);
            }
            else
            {
                this.currans = 4;
                this.QueueAudio(this.notes[3]);
            }
            if (this.problem == 4)
            {
                this.endDelay = 5f;
                if (!this.gc.spoopMode)
                {
                    this.questionText.text = "Great Job!";
                    gc.GetComponent<TicketsScript>().AddTickets(20);
                    return;
                }
                if (this.gc.mode == "endless" & this.problemsWrong <= 0)
                {
                    int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
                    this.questionText.text = this.endlessHintText[num];
                    gc.GetComponent<TicketsScript>().AddTickets(10);
                    return;
                }
                if (this.gc.mode == "story" & this.problemsWrong >= 3)
                {
                    this.questionText.text = "ARE YOU K I D D I N G  ME!?";
                    this.questionText2.text = string.Empty;
                    this.questionText3.text = string.Empty;
                    this.baldiScript.Hear(this.playerPosition, 10f);
                    gc.GetComponent<TicketsScript>().AddTickets(15);
                    this.gc.failedNotebooks++;
                    return;
                }
                int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
                this.questionText.text = this.hintText[num2];
                this.questionText2.text = string.Empty;
                this.questionText3.text = string.Empty;
                gc.GetComponent<TicketsScript>().AddTickets(20);
            }
        }
    }

    // Token: 0x0600012F RID: 303 RVA: 0x000075F4 File Offset: 0x000057F4
    public void CheckAnswer(int answer)
    {
        if (answer == this.currans)
        {
            this.results[this.problem - 1].texture = this.correct;
            this.baldiAudio.Stop();
            this.ClearAudioQueue();
            int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 4f));
            if (!this.gc.spoopMode)
            {
                this.QueueAudio(this.bal_praises[num]);
            }
            this.NewProblem();
            return;
        }
        this.problemsWrong++;
        this.results[this.problem - 1].texture = this.incorrect;
        if (!this.gc.spoopMode)
        {
            this.baldiFeed.SetTrigger("angry");
            this.gc.ActivateSpoopMode();
        }
        if (this.gc.mode == "story")
        {
            if (this.problem == 3)
            {
                this.baldiScript.GetAngry(1f);
            }
            else
            {
                this.baldiScript.GetTempAngry(0.25f);
            }
        }
        else
        {
            this.baldiScript.GetAngry(1f);
        }
        this.ClearAudioQueue();
        this.baldiAudio.Stop();
        this.NewProblem();
    }

    // Token: 0x06000130 RID: 304 RVA: 0x00007727 File Offset: 0x00005927
    private void QueueAudio(AudioClip sound)
    {
        this.audioQueue[this.audioInQueue] = sound;
        this.audioInQueue++;
    }

    // Token: 0x06000131 RID: 305 RVA: 0x00007745 File Offset: 0x00005945
    private void PlayQueue()
    {
        this.baldiAudio.PlayOneShot(this.audioQueue[0]);
        this.UnqueueAudio();
    }

    // Token: 0x06000132 RID: 306 RVA: 0x00007760 File Offset: 0x00005960
    private void UnqueueAudio()
    {
        for (int i = 1; i < this.audioInQueue; i++)
        {
            this.audioQueue[i - 1] = this.audioQueue[i];
        }
        this.audioInQueue--;
    }

    // Token: 0x06000133 RID: 307 RVA: 0x0000779E File Offset: 0x0000599E
    private void ClearAudioQueue()
    {
        this.audioInQueue = 0;
    }

    // Token: 0x06000134 RID: 308 RVA: 0x000077A8 File Offset: 0x000059A8
    private void ExitGame()
    {
        if (this.problemsWrong <= 0 & this.gc.mode == "endless")
        {
            this.baldiScript.GetAngry(-1f);
        }
        this.gc.DeactivateLearningGame(base.gameObject);
    }

    // Token: 0x040001BE RID: 446
    public AudioClip[] notes = new AudioClip[4];

    // Token: 0x040001BF RID: 447
    public int currans;

    // Token: 0x040001C0 RID: 448
    public GameControllerScript gc;

    // Token: 0x040001C1 RID: 449
    public BaldiScript baldiScript;

    // Token: 0x040001C2 RID: 450
    public Vector3 playerPosition;

    // Token: 0x040001C3 RID: 451
    public GameObject mathGame;

    // Token: 0x040001C4 RID: 452
    public RawImage[] results = new RawImage[3];

    // Token: 0x040001C5 RID: 453
    public Texture correct;

    // Token: 0x040001C6 RID: 454
    public Texture incorrect;

    // Token: 0x040001C7 RID: 455
    public InputField playerAnswer;

    // Token: 0x040001C8 RID: 456
    public Text questionText;

    // Token: 0x040001C9 RID: 457
    public Text questionText2;

    // Token: 0x040001CA RID: 458
    public Text questionText3;

    // Token: 0x040001CB RID: 459
    public Animator baldiFeed;

    // Token: 0x040001CC RID: 460
    public Transform baldiFeedTransform;

    // Token: 0x040001CD RID: 461
    public AudioClip bal_plus;

    // Token: 0x040001CE RID: 462
    public AudioClip bal_minus;

    // Token: 0x040001CF RID: 463
    public AudioClip bal_times;

    // Token: 0x040001D0 RID: 464
    public AudioClip bal_divided;

    // Token: 0x040001D1 RID: 465
    public AudioClip bal_equals;

    // Token: 0x040001D2 RID: 466
    public AudioClip bal_howto;

    // Token: 0x040001D3 RID: 467
    public AudioClip bal_intro;

    // Token: 0x040001D4 RID: 468
    public AudioClip bal_screech;

    // Token: 0x040001D5 RID: 469
    public AudioClip[] bal_numbers = new AudioClip[10];

    // Token: 0x040001D6 RID: 470
    public AudioClip[] bal_praises = new AudioClip[5];

    // Token: 0x040001D7 RID: 471
    public AudioClip[] bal_problems = new AudioClip[3];

    // Token: 0x040001D8 RID: 472
    private float endDelay;

    // Token: 0x040001D9 RID: 473
    private int problem;

    // Token: 0x040001DA RID: 474
    private int audioInQueue;

    // Token: 0x040001DB RID: 475
    private float num1;

    // Token: 0x040001DC RID: 476
    private float num2;

    // Token: 0x040001DD RID: 477
    private float num3;

    // Token: 0x040001DE RID: 478
    private int sign;

    // Token: 0x040001DF RID: 479
    private float solution;

    // Token: 0x040001E0 RID: 480
    private string[] hintText = new string[]
    {
        "I Will Slice Your Throat...",
        "My EARS ARE BLEEDING..."
    };

    // Token: 0x040001E1 RID: 481
    private string[] endlessHintText = new string[]
    {
        "...",
        "...?"
    };

    // Token: 0x040001E2 RID: 482
    private bool questionInProgress;

    // Token: 0x040001E3 RID: 483
    private bool impossibleMode;

    // Token: 0x040001E4 RID: 484
    private int problemsWrong;

    // Token: 0x040001E5 RID: 485
    private AudioClip[] audioQueue = new AudioClip[20];

    // Token: 0x040001E6 RID: 486
    public AudioSource baldiAudio;
}
