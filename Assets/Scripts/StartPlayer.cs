using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class StartPlayer : NetworkBehaviour
{

    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>(default,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Server); 

    public override void NetworkStart()
    {
        Move();
    }

    public void Move() {

        if (NetworkManager.Singleton.IsServer) {
            Vector3 randomPosition = GetRandomPositionOnPlane();

            transform.position = randomPosition;

            Position.Value = randomPosition;
        } 
        else 
        {
            SubmitPositionRequestServerRpc();
        }

    }

    [ServerRpc]
    void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default) {

        Position.Value = GetRandomPositionOnPlane();

    }

    static Vector3 GetRandomPositionOnPlane() { 
        float MinimumPosition = -4f;

        float MaximumPosition = 4f;

        float xPosition = Random.Range(MinimumPosition, MaximumPosition);

        float yPosition = 1f;

        float zPosition = Random.Range(MinimumPosition, MaximumPosition);

        return new Vector3(xPosition, yPosition, zPosition);
    } 

    void Update()
    {
        transform.position = Position.Value;
    }
}
