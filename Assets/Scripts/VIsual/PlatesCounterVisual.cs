using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCourter platesCourter;
    [SerializeField] private Transform counterTopint;
    [SerializeField] private Transform plateVisualPrefab;

    private List<GameObject> plateVisualGameobjectList;

    private void Awake()
    {
        plateVisualGameobjectList = new List<GameObject>();
    }

    private void Start()
    {
        platesCourter.OnPlateSpawned += OnPlatesCourter_OnPlateSpawned;
        platesCourter.OnPlateRemove += OnPlatesCourter_OnPlateRemove;
    }
    /// <summary>
    /// ÒÆ³ýÅÌ×Ó
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnPlatesCourter_OnPlateRemove(object sender, System.EventArgs e)
    {
        int lenght = plateVisualGameobjectList.Count;
        if (lenght == 1)
            platesCourter.ClearKitchenObject();
        GameObject plateGameObject = plateVisualGameobjectList[lenght - 1];
        plateVisualGameobjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

    private void OnPlatesCourter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopint);
        float plateOffsetY = .1f;
        Debug.Log(.1f);
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVisualGameobjectList.Count, 0);
        plateVisualGameobjectList.Add(plateVisualTransform.gameObject);
    }
}
