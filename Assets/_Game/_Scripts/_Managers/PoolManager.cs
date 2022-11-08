using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField]
    private PoolInfo poolSettings;
    
    [SerializeField]
    private Transform poolHolder;

    private void Awake()
    {
        InitializeBalls();
    }
    public void InitializeBalls()
    {
        ObjectPooler.GeneratePool(poolSettings, poolHolder);
    }
    public void ResetPool()
    {
        ObjectPooler.ResetQueue();
    }
}