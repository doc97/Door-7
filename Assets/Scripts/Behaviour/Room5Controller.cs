using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Room5Controller : RoomController
{
    #region fields
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject roomTransitionObject;
    [SerializeField]
    private Text[] texts;

    private RoomTransition roomTransition;
    private Rigidbody2D playerBody;
    #endregion

    void Start()
    {
        Debug.Assert(texts.Length > 0);
        roomTransition = roomTransitionObject.GetComponent<RoomTransition>();
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    protected override void OnUpdate()
    {
        if (player.transform.position.y < -10)
            roomTransition.GotoRoom(0, true);
    }

    protected override void OnActivate()
    {
        texts[0].color = Color.white;
        for (int i = 1; i < texts.Length; ++i)
            texts[i].color = new Color(1, 1, 1, 0);

        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(5);
        seq.Append(texts[0].DOFade(0, 1));
        for (int i = 1; i < texts.Length; ++i)
        {
            seq.AppendInterval(0.5f);
            seq.Append(texts[i].DOFade(1, 1));
            seq.AppendInterval(3.5f);
            seq.Append(texts[i].DOFade(0, 1));
        }
        seq.Play();

        // Activate player's rigidbody for this room
        playerBody.simulated = true;
    }

    protected override void OnDeactivate()
    {
        // Deactivate and reset player's rigidbody, since it's no longer needed
        playerBody.simulated = false;
        playerBody.rotation = 0;
        playerBody.velocity = Vector2.zero;
        playerBody.angularVelocity = 0;
        playerBody.inertia = 0;

        // Also reset the transform rotation
        player.transform.rotation = Quaternion.identity;
    }
}