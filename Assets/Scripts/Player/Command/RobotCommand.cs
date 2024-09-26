using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotCommand : MonoBehaviour
{
    Queue<Command> commands = new Queue<Command>();


    public FriendlyRobot robot;
    [SerializeField] private GameObject pointerPrefab;
    [SerializeField] private Camera cam;

    private Ray ray;
    private Command currentCommand;

    private void Update()
    {
        ProcessCommands();
    }

    public void Command()
    {
        if(robot == null) return;
        if (!robot.GetActivity()) return;

        ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out var hitInfo))
        {
            if (hitInfo.transform.CompareTag("Ground"))
            {
                GameObject pointer = Instantiate(pointerPrefab);
                pointer.transform.position = hitInfo.point;

                commands.Enqueue(new MoveCommand(robot.agent, hitInfo.point));
                Destroy(pointer, 5f);
            }
            else if (hitInfo.transform.CompareTag("Builder"))
            {
                commands.Enqueue(new BuildCommand(robot.agent, hitInfo.transform.GetComponent<Builder>()));
            }
            else if (hitInfo.transform.CompareTag("RobotDelivery"))
            {
                commands.Enqueue(new DeliverCommand(robot.agent, hitInfo.transform.GetComponent<DeliveryZone>(), robot.attachedObject));
            }
        }
    }

    private void ProcessCommands()
    {
        if (robot == null) return;
        if (!robot.GetActivity()) return;

        if (currentCommand != null && !currentCommand.isComplete) return;
        if(commands.Count == 0) return;

        currentCommand = commands.Dequeue();
        currentCommand.Execute();
    }

    public void AssignRobot(FriendlyRobot _robot)
    {
        robot = _robot;
    }
}
