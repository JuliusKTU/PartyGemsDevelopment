
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsManager : MonoBehaviour
{
    private float DefaultRunSpeed = 200;
    private float DefaultJump = 1300;


    public GameObject RandomBuff;
    public GameObject Shield;
    private Vector3[] PossiblePositions = {new Vector3(0, 4, 10),
                                           new Vector3(0, -2, 10),
                                           new Vector3(-15, 2, 10),
    new Vector3(15, 2, 10),
    new Vector3(-17, 6, 10),
    new Vector3(17, 6, 10),
    new Vector3(-5, -7, 10),
    new Vector3(5, -7, 10),
    new Vector3(-13, -10, 10),
    new Vector3(13, 2, 10)
    };

    public float SpawnedObjectVisibleDuration = 4f;
    public float SpawnRandomItemTimeRatio = 15f;
    private float RandomItemTimeDuration = 0f;

    private bool BuffApplied = false;
    public float BuffMaintainsTime = 1f;
    private float BuffTimer;
    private GameObject buffedPlayer;

    private int SpawnShieldRatio = 0;

    // Start is called before the first frame update
    void Start()
    {
        RandomItemTimeDuration = SpawnRandomItemTimeRatio;
        BuffTimer = BuffMaintainsTime;
 
    }

    // Update is called once per frame
    void Update()
    {
        RandomItemTimeDuration -= Time.deltaTime;
        if (RandomItemTimeDuration < 0)
        {
            SpawnShieldRatio++;
            Debug.Log("Buff was spawned");
            GameObject a = Instantiate(RandomBuff) as GameObject;
            a.transform.position = PossiblePositions[GetRandomBuffNumber()];
            if(a != null)
            {
                Destroy(a, SpawnedObjectVisibleDuration);
            }


            RandomItemTimeDuration = SpawnRandomItemTimeRatio;
        }

        if (BuffApplied)
        {
            BuffTimer -= Time.deltaTime;
            if (BuffTimer < 0)
            {
                BuffApplied = false;
                BuffTimer = BuffMaintainsTime;
                RemoveAllBuffs(buffedPlayer);

            }
        }

        if (SpawnShieldRatio == 2)
        {
            GameObject b = Instantiate(Shield) as GameObject;
            b.transform.position = PossiblePositions[GetRandomBuffNumber()];
            if (b != null)
            {
                Destroy(b, SpawnedObjectVisibleDuration);
                SpawnShieldRatio = 0;
            }


        }

    }

    private int GetRandomBuffNumber()
    {
        return Random.Range(0, PossiblePositions.Length);
    }

    public void SetBuffedPlayer(GameObject player)
    {
        if(BuffApplied != true) //if no one has a buff
        {
            buffedPlayer = player;
            BuffApplied = true;
        }
    }

    private void RemoveAllBuffs(GameObject player)
    {
        player.GetComponent<PlayerMovement>().runSpeed -= player.GetComponent<PlayerMovement>().runSpeed - DefaultRunSpeed;
        player.GetComponent<CharacterController2D>().m_JumpForce -= player.GetComponent<CharacterController2D>().m_JumpForce - DefaultJump;
    }

}
