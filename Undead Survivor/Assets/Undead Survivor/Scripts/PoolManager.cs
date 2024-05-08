using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //프리펩들을 보관할 변수
    public GameObject[] prefabs;

    //풀 담당을 하는 리시트들
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < pools.Length; i++){
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        for (int i = 0; i < pools[index].Count; i++){
            if (!pools[index][i].activeSelf){
                select = pools[index][i];
                break;
            }
        }
        if(!select){
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
