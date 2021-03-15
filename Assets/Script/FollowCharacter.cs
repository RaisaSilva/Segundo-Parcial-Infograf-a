using UnityEngine;
using Cinemachine;

public class FollowCharacter : MonoBehaviour
{
    public GameObject player;
    public Transform followTarget;
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                followTarget = player.transform;
                vcam.LookAt = followTarget;
                vcam.Follow = followTarget;
            }
        }
    }
}
