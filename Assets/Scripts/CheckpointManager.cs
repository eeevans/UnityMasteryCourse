using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Checkpoint[] checkpoints;

    void Start()
    {
        checkpoints = GetComponentsInChildren<Checkpoint>();
    }

    public Checkpoint GetLastCheckpointThatWasPassed()
    {
        Checkpoint checkpoint = checkpoints.LastOrDefault(c => c.Passed);
        checkpoint = checkpoint ?? checkpoints[0];
        return checkpoint;
    }
}
