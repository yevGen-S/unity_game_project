using UnityEngine;
using Mirror;

public class EnemyDestroy : NetworkBehaviour
{
    public void Die()
    {
        if (isServer)
            NetworkServer.Destroy(gameObject);
    }
}
