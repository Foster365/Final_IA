using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterModel : MonoBehaviour
{
    [SerializeField] List<Transform> patrollingNodes;
    [SerializeField] List<Transform> wp;
    public List<Transform> waypoints;
    List<Node> targetSeekNodes;
    public float speed = .1f;
    public float rotationSpeed = 1;
    bool readyToMove = false;
    int _nextWaypoint = 0, waypointIndexModifier = 1;
    Rigidbody rb;
    Grid mapGrid;
    Vector3 pathfindingLastPosition;

    //Pathfinding
    Pathfinding characterPathfinding;

    [SerializeField] Transform target;
    public Vector3 PathfindingLastPosition { get => pathfindingLastPosition; set => pathfindingLastPosition = value; }
    public Transform Target { get => target; set => target = value; }
    public Pathfinding CharacterPathfinding { get => characterPathfinding; set => characterPathfinding = value; }
    public Grid MapGrid { get => mapGrid; set => mapGrid = value; }
    public bool ReadyToMove { get => readyToMove; set => readyToMove = value; }
    public List<Node> TargetSeekNodes { get => targetSeekNodes; set => targetSeekNodes = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mapGrid = GameObject.Find("Grid").GetComponent<Grid>();
    }

    private void Start()
    {
        pathfindingLastPosition = Vector3.zero;
        new List<Node>();
    }

    public void Patrol(Pathfinding _pathfinding)
    {
        Vector3 _patrollingLastPos = Vector3.zero;
        List<Node> _waypoints = new List<Node>();
        for (int i = 0; i < patrollingNodes.Count; i++)
        {
            if (Vector3.Distance(patrollingNodes[i].position, _patrollingLastPos) > 1)
            {
                Debug.Log("Ok to find path");
                Debug.Log("Patrolling node: " + patrollingNodes[i].name);
                _patrollingLastPos = patrollingNodes[i].position;
                _pathfinding.FindPath(transform.position, _patrollingLastPos);
                _waypoints = _pathfinding.finalPath;
                //Run(_waypoints);
            }
            else return;
        }
    }
    public void PatrolSimple()
    {
        Run(wp);
    }

    public void Move(Vector3 dir)
    {
        Debug.Log("Ok to move");
        dir *= speed;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
        //_anim.SetFloat("Vel", 1);
    }
    public void SetWayPoints(List<Transform> newPoints) //<Node>
    {
        _nextWaypoint = 0;
        if (newPoints.Count == 0) return;
        //_anim.Play("CIA_Idle");
        //waypoints = newPoints;
        waypoints = wp;
        var pos = waypoints[_nextWaypoint].position;
        //var pos = waypoints[_nextPoint].worldPosition;
        pos.y = transform.position.y;
        transform.position = pos;
        readyToMove = true;
        Debug.Log("Ok");
    }
    public void Run(List<Transform> _waypoints)
    {
        var waypoint = _waypoints[_nextWaypoint];
        var waypointPosition = waypoint.position;
        waypointPosition.y = transform.position.y;
        Vector3 dir = waypointPosition - transform.position;
        if (dir.magnitude < 3)
        {
            if (_nextWaypoint + waypointIndexModifier >= _waypoints.Count || _nextWaypoint + waypointIndexModifier < 0)
                waypointIndexModifier *= -1;
            _nextWaypoint += waypointIndexModifier;
            readyToMove = true;
        }
        else if(readyToMove) Move(dir.normalized);
        // return dir;

        //Debug.Log("Ok to run");
        //var point = _waypoints[_nextPoint];
        //var posPoint = point.position;
        ////var posPoint = point.worldPosition;
        //posPoint.y = transform.position.y;
        //Vector3 dir = posPoint - transform.position;
        //if (dir.magnitude < 0.2f)
        //{
        //    if (_nextPoint + 1 < _waypoints.Count)
        //        _nextPoint++;
        //    else
        //    {
        //        readyToMove = false;
        //        //_anim.SetTrigger("Finish");
        //        //_anim.SetFloat("Vel", 0);
        //        return;
        //    }
        //}
        //Move(dir.normalized);
    }
    public void Run(List<Node> _waypoints)
    {
        var waypoint = _waypoints[_nextWaypoint];
        var waypointPosition = waypoint.worldPosition;
        waypointPosition.y = transform.position.y;
        Vector3 dir = waypointPosition - transform.position;
        if (dir.magnitude < 1)
        {
            if (_nextWaypoint + waypointIndexModifier >= _waypoints.Count || _nextWaypoint + waypointIndexModifier < 0)
                waypointIndexModifier *= -1;
            _nextWaypoint += waypointIndexModifier;
            readyToMove = true;
        }
        else if (readyToMove) Move(dir.normalized);
    }
}
