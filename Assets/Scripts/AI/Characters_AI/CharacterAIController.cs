using System.Collections;
using System.Collections.Generic;
using UADE.IA.FSM;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterAIController : MonoBehaviour
{

    CharacterModel charModel;

    //FSM Variables
    FSM<string> leaderFSM;

    //Line of Sight variables
    LineOfSight characterLineOfSight;
    [SerializeField] float lineOfSightViewDistance;
    [SerializeField] float lineOfSightViewCone;
    [SerializeField] RaycastHit lineOfSightHitInfo;
    [SerializeField] LayerMask lineOfSightObstacleLayer;
    [SerializeField] LayerMask lineOfSightTarget;

    //Pathfinding variables
    Pathfinding characterPathfinding;

    public LineOfSight CharacterLineOfSight { get => characterLineOfSight; set => characterLineOfSight = value; }
    public CharacterModel CharModel { get => charModel; set => charModel = value; }
    public Pathfinding CharacterPathfinding { get => characterPathfinding; set => characterPathfinding = value; }

    private void Awake()
    {
        charModel = GetComponent<CharacterModel>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpAIComponents();
    }

    // Update is called once per frame
    void Update()
    {
        //charModel.Patrol(characterPathfinding);
        leaderFSM.OnUpdate();
    }

    public void SetUpAIComponents()
    {
        SetUpFSM();
        characterLineOfSight = new LineOfSight(lineOfSightViewDistance, lineOfSightViewCone, lineOfSightHitInfo,
                                            transform, lineOfSightObstacleLayer, lineOfSightTarget);
        characterPathfinding = new Pathfinding(transform, charModel.Target, charModel.PathfindingLastPosition, charModel.MapGrid);
    }
    void SetUpFSM()
    {

        leaderFSM = new FSM<string>();

        LeaderIdleState<string> leaderIdleState = new LeaderIdleState<string>(this, 3, leaderFSM, "LeaderPatrolState", "LeaderAttackState", "LeaderBlockState", "LeaderDamageState");
        LeaderPatrolState<string> leaderPatrolState = new LeaderPatrolState<string>(this, 10f, leaderFSM, "LeaderIdleState", "LeaderSeekState");
        LeaderSeekState<string> leaderSeekState = new LeaderSeekState<string>(this, leaderFSM, "LeaderPatrolState", "LeaderAttackState");
        //LeaderAttackState<string> leaderAttackState = new LeaderAttackState<string>(this, leaderFSM, "LeaderSeekState", "LeaderDamageState");
        //LeaderBlockState<string> leaderBlockState = new LeaderBlockState<string>(this, leaderFSM, "LeaderIdleState");
        //LeaderDamageState<string> leaderDamageState = new LeaderDamageState<string>(this, leaderFSM, "LeaderAttackState", "LeaderIdleState", "LeaderDeathState");
        //LeaderDeathState<string> leaderDeathState = new LeaderDeathState<string>(leaderFSM);

        leaderIdleState.AddTransition("LeaderPatrolState", leaderPatrolState);
        //leaderIdleState.AddTransition("LeaderAttackState", leaderAttackState);
        //leaderIdleState.AddTransition("LeaderBlockState", leaderBlockState);
        //leaderIdleState.AddTransition("LeaderDamageState", leaderDamageState);

        leaderPatrolState.AddTransition("LeaderIdleState", leaderIdleState);
        leaderPatrolState.AddTransition("LeaderSeekState", leaderSeekState);

        //leaderSeekState.AddTransition("LeaderIdleState", leaderIdleState);
        //leaderSeekState.AddTransition("LeaderSeekState", leaderAttackState);

        //leaderAttackState.AddTransition("LeaderSeekState", leaderSeekState);
        //leaderAttackState.AddTransition("LeaderDamageState", leaderDamageState);

        //leaderBlockState.AddTransition("LeaderIdleState", leaderIdleState);

        //leaderDamageState.AddTransition("LeaderAttackState", leaderAttackState);
        //leaderDamageState.AddTransition("LeaderIdleState", leaderIdleState);

        leaderFSM.SetInit(leaderIdleState);

    }

}
